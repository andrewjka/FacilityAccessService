#region

using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Domain.CommonScope.PersistenceContext;
using Domain.CommonScope.Specification;
using Domain.UserScope.Actions;
using Domain.UserScope.Models;
using Domain.UserScope.Services;
using Domain.UserScope.ValueObjects;
using FluentValidation;

#endregion

namespace Business.UserScope.Services;

public class UserService : IUserService
{
    private readonly IPersistenceContextFactory _persistenceContextFactory;
    private readonly IValidator<RegistryUserModel> _registryUserVL;
    private readonly IValidator<User> _userVL;


    public UserService(
        IValidator<RegistryUserModel> registryUserVL,
        IValidator<User> userVl,
        IPersistenceContextFactory persistenceContextFactory
    )
    {
        if (registryUserVL is null) throw new ArgumentNullException(nameof(registryUserVL));
        if (persistenceContextFactory is null) throw new ArgumentNullException(nameof(persistenceContextFactory));

        _registryUserVL = registryUserVL;
        _userVL = userVl;
        _persistenceContextFactory = persistenceContextFactory;
    }


    public async Task<User> RegistryUserAsync(RegistryUserModel registryModel)
    {
        _registryUserVL.ValidateAndThrow(registryModel);


        var user = new User(registryModel.Email, registryModel.Password, Role.Employee);

        _userVL.ValidateAndThrow(user);


        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            await context.UserRepository.CreateAsync(user);

            await context.ApplyChangesAsync();
            await context.CommitAsync();
        }

        return user;
    }

    public async Task<User> GetUserAsync(Specification<User> specification)
    {
        User user;
        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            user = await context.UserRepository.FirstByAsync(specification);
        }

        return user;
    }

    public async Task<ReadOnlyCollection<User>> GetUsersAsync(Specification<User> specification)
    {
        ReadOnlyCollection<User> users;
        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            users = await context.UserRepository.SelectByAsync(specification);
        }

        return users;
    }
}
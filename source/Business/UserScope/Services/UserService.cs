#region

using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Domain.CommonScope.Helpers;
using Domain.CommonScope.PersistenceContext;
using Domain.CommonScope.Services;
using Domain.CommonScope.Specification;
using Domain.UserScope.Actions;
using Domain.UserScope.Exceptions;
using Domain.UserScope.Models;
using Domain.UserScope.Services;
using Domain.UserScope.Specifications;
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
        if (userVl is null) throw new ArgumentNullException(nameof(userVl));

        _registryUserVL = registryUserVL;
        _userVL = userVl;
        _persistenceContextFactory = persistenceContextFactory;
    }


    public async Task<User> RegistryUserAsync(RegistryUserModel registryModel)
    {
        _registryUserVL.ValidateAndThrow(registryModel);


        if (registryModel.role != Role.Guest || registryModel.role != Role.Employee
                                             || registryModel.role != Role.Guard)
        {
            throw new Exception($"This role {registryModel.role} is not allowed to registry.");
        }


        var user = new User(registryModel.Email, PasswordHasher.Hash(registryModel.Password), registryModel.role);

        _userVL.ValidateAndThrow(user);


        bool isEmailClaimed = await GetUserAsync(new FindByEmailSpecification(registryModel.Email)) != null;
        if (isEmailClaimed)
        {
            throw new SuchUserAlreadyRegisteredException("User with the specified email already exists.");
        }


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
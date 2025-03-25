#region

using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FacilityAccessService.Business.CommonScope.PersistenceContext;
using FacilityAccessService.Business.CommonScope.Specification;
using FacilityAccessService.Business.UserScope.Actions;
using FacilityAccessService.Business.UserScope.Models;
using FacilityAccessService.Business.UserScope.Services;
using FacilityAccessService.Business.UserScope.ValueObjects;
using FluentValidation;

#endregion

namespace FacilityAccessService.Domain.UserScope.Services
{
    public class UserService : IUserService
    {
        private readonly IValidator<RegistryUserModel> _registryUserVL;
        private readonly IValidator<User> _userVL;

        private readonly IPersistenceContextFactory _persistenceContextFactory;


        public UserService(
            IValidator<RegistryUserModel> registryUserVL,
            IValidator<User> userVl,
            IPersistenceContextFactory persistenceContextFactory
        )
        {
            if (registryUserVL is null) throw new ArgumentNullException(nameof(registryUserVL));
            if (persistenceContextFactory is null) throw new ArgumentNullException(nameof(persistenceContextFactory));

            this._registryUserVL = registryUserVL;
            this._userVL = userVl;
            this._persistenceContextFactory = persistenceContextFactory;
        }


        public async Task<User> RegistryUserAsync(RegistryUserModel registryUserModel)
        {
            _registryUserVL.ValidateAndThrow(registryUserModel);


            User user = new User(
                externalUserId: registryUserModel.ExternalUserId,
                role: Role.Employee
            );

            _userVL.ValidateAndThrow(user);


            await using (IPersistenceContext context = await _persistenceContextFactory.CreatePersistenceContextAsync())
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
            await using (IPersistenceContext context = await _persistenceContextFactory.CreatePersistenceContextAsync())
            {
                user = await context.UserRepository.FirstByAsync(specification);
            }

            return user;
        }

        public async Task<ReadOnlyCollection<User>> GetUsersAsync(Specification<User> specification)
        {
            ReadOnlyCollection<User> users;
            await using (IPersistenceContext context = await _persistenceContextFactory.CreatePersistenceContextAsync())
            {
                users = await context.UserRepository.SelectByAsync(specification);
            }

            return users;
        }
    }
}
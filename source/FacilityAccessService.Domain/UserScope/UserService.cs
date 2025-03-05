using System;
using System.Threading.Tasks;
using FacilityAccessService.Business.UserScope.Actions;
using FacilityAccessService.Business.UserScope.Models;
using FacilityAccessService.Business.UserScope.Repositories;
using FacilityAccessService.Business.UserScope.Services;
using FacilityAccessService.Business.UserScope.ValueObjects;
using FluentValidation;

namespace FacilityAccessService.Domain.UserScope
{
    public class UserService : IUserService
    {
        private IValidator<RegistryUserModel> _registryUserVL;
        private IValidator<User> _userVL;
        
        private IUserRepository _userRepository;


        public UserService(
            IValidator<RegistryUserModel> registryUserVL,
            IValidator<User> userVl,
            IUserRepository userRepository
        )
        {
            if (registryUserVL is null) throw new ArgumentNullException(nameof(registryUserVL));
            if (userRepository is null) throw new ArgumentNullException(nameof(userRepository));
            if (userVl is null) throw new ArgumentNullException(nameof(userVl));


            this._registryUserVL = registryUserVL;
            this._userVL = userVl;
            this._userRepository = userRepository;
        }


        public async Task<User> RegistryUserAsync(RegistryUserModel registryUserModel)
        {
            _registryUserVL.ValidateAndThrow(registryUserModel);

            
            User user = new User(
                externalUserId: registryUserModel.ExternalUserId,
                role: Role.Employee
            );

            _userVL.ValidateAndThrow(user);

            
            await _userRepository.CreateAsync(user);

            return user;
        }
    }
}
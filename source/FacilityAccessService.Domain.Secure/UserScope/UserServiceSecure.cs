#region

using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FacilityAccessService.Business.CommonScope.Specification;
using FacilityAccessService.Business.UserScope.Actions;
using FacilityAccessService.Business.UserScope.Models;
using FacilityAccessService.Business.UserScope.Services;
using FacilityAccessService.Business.UserScope.ValueObjects;
using FacilityAccessService.Domain.Secure.CommonScope.Abstractions;
using FacilityAccessService.Domain.Secure.CommonScope.Context;
using FacilityAccessService.Domain.Secure.UserScope.Interfaces;

#endregion

namespace FacilityAccessService.Domain.Secure.UserScope
{
    public class UserServiceSecure : BaseUserAuthorization, IUserServiceSecure
    {
        private readonly IUserService _userService;


        public UserServiceSecure(IUserService userService, IUserContext userContext) : base(userContext)
        {
            this._userService = userService;
        }


        /// <summary>
        /// It is forbidden to create a new user, this is the responsibility of the internal workings of the service.
        /// </summary>
        /// <returns>Always returns exception</returns>
        /// <exception cref="UnauthorizedAccessException"></exception>
        public async Task<User> RegistryUserAsync(RegistryUserModel registryUserModel)
        {
            throw new UnauthorizedAccessException("Forbidden action.");
        }

        public async Task<User> GetUserAsync(Specification<User> specification)
        {
            return await _userService.GetUserAsync(specification);
        }

        public async Task<ReadOnlyCollection<User>> GetUsersAsync(Specification<User> specification)
        {
            return await _userService.GetUsersAsync(specification);
        }

        protected override void EnsureHasPermission()
        {
            bool hasAccess = _userContext.User.Role.CheckPermission(Permission.CanMaintenanceUsers);
            if (hasAccess is false)
            {
                throw new UnauthorizedAccessException(
                    "The current user does not have permission to maintain users."
                );
            }
        }
    }
}
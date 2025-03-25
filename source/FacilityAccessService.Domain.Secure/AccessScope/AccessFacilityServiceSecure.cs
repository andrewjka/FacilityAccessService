#region

using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FacilityAccessService.Business.AccessScope.Actions;
using FacilityAccessService.Business.AccessScope.Models;
using FacilityAccessService.Business.AccessScope.Services;
using FacilityAccessService.Business.CommonScope.Specification;
using FacilityAccessService.Business.UserScope.ValueObjects;
using FacilityAccessService.Domain.Secure.AccessScope.Interfaces;
using FacilityAccessService.Domain.Secure.CommonScope.Abstractions;
using FacilityAccessService.Domain.Secure.CommonScope.Context;

#endregion

namespace FacilityAccessService.Domain.Secure.AccessScope
{
    public class AccessFacilityServiceSecure : BaseUserAuthorization, IAccessFacilityServiceSecure
    {
        private readonly IAccessFacilityService _accessFacility;


        public AccessFacilityServiceSecure(IAccessFacilityService accessFacility, IUserContext userContext)
            : base(userContext)
        {
            if (accessFacility is null) throw new ArgumentNullException(nameof(accessFacility));

            this._accessFacility = accessFacility;
        }


        public async Task GrantAccessAsync(GrantAccessFacilityModel grantAccessModel)
        {
            await _accessFacility.GrantAccessAsync(grantAccessModel);
        }

        public async Task RevokeAccessAsync(RevokeAccessFacilityModel revokeAccessModel)
        {
            await _accessFacility.RevokeAccessAsync(revokeAccessModel);
        }

        public async Task UpdateAccessAsync(UpdateAccessFacilityModel updateAccessModel)
        {
            await _accessFacility.UpdateAccessAsync(updateAccessModel);
        }

        public async Task<UserFacility> GetAccessUserFacilityAsync(Specification<UserFacility> specification)
        {
            return await _accessFacility.GetAccessUserFacilityAsync(specification);
        }

        public async Task<ReadOnlyCollection<UserFacility>> GetAccessUserFacilitiesAsync(
            Specification<UserFacility> specification
        )
        {
            return await _accessFacility.GetAccessUserFacilitiesAsync(specification);
        }

        protected override void EnsureHasPermission()
        {
            bool hasAccess = _userContext.User.Role.CheckPermission(Permission.CanMaintenanceAccess);
            if (hasAccess is false)
            {
                throw new UnauthorizedAccessException(
                    "The current user does not have permission to maintenance accesses."
                );
            }
        }
    }
}
using System;
using System.Threading.Tasks;
using FacilityAccessService.Business.AccessScope.Actions;
using FacilityAccessService.Business.AccessScope.Services;
using FacilityAccessService.Business.UserScope.ValueObjects;
using FacilityAccessService.Domain.Secure.AccessScope.Interfaces;
using FacilityAccessService.Domain.Secure.CommonScope.Abstractions;
using FacilityAccessService.Domain.Secure.CommonScope.Context;

namespace FacilityAccessService.Domain.Secure.AccessScope
{
    public class AccessFacilityServiceSecure : BaseServiceSecure, IAccessFacilityServiceSecure
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
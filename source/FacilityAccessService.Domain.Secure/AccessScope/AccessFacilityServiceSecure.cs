#region

using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FacilityAccessService.Business.AccessScope.Actions;
using FacilityAccessService.Business.AccessScope.Models;
using FacilityAccessService.Business.AccessScope.Services;
using FacilityAccessService.Business.CommonScope.Specification;
using FacilityAccessService.Business.UserScope.ValueObjects;
using FacilityAccessService.Domain.Secure.AccessScope.Context;
using FacilityAccessService.Domain.Secure.AccessScope.Interfaces;
using FacilityAccessService.Domain.Secure.CommonScope.Abstractions;
using FacilityAccessService.Domain.Secure.CommonScope.Context;

#endregion

namespace FacilityAccessService.Domain.Secure.AccessScope
{
    public class AccessFacilityServiceSecure : BaseUserAuthorization, IAccessFacilityServiceSecure
    {
        private readonly IAccessFacilityService _accessFacility;

        private readonly IUserQueryContext _queryContext;


        public AccessFacilityServiceSecure(
            IAccessFacilityService accessFacility,
            IUserContext userContext,
            IUserQueryContext userQueryContext)
            : base(userContext)
        {
            if (accessFacility is null) throw new ArgumentNullException(nameof(accessFacility));
            if (userContext is null) throw new ArgumentNullException(nameof(userContext));
            if (userQueryContext is null) throw new ArgumentNullException(nameof(userQueryContext));

            this._accessFacility = accessFacility;
            this._queryContext = userQueryContext;
        }


        public async Task GrantAccessAsync(GrantAccessFacilityModel grantAccessModel)
        {
            EnsureHasMaintenancePermission();
            await _accessFacility.GrantAccessAsync(grantAccessModel);
        }

        public async Task RevokeAccessAsync(RevokeAccessFacilityModel revokeAccessModel)
        {
            EnsureHasMaintenancePermission();
            await _accessFacility.RevokeAccessAsync(revokeAccessModel);
        }

        public async Task UpdateAccessAsync(UpdateAccessFacilityModel updateAccessModel)
        {
            EnsureHasMaintenancePermission();
            await _accessFacility.UpdateAccessAsync(updateAccessModel);
        }

        public async Task<UserFacility> GetAccessAsync(Specification<UserFacility> specification)
        {
            EnsureHasSelectPermission();
            return await _accessFacility.GetAccessAsync(specification);
        }

        public async Task<ReadOnlyCollection<UserFacility>> GetAccessesAsync(
            Specification<UserFacility> specification
        )
        {
            EnsureHasSelectPermission();
            return await _accessFacility.GetAccessesAsync(specification);
        }

        protected override void EnsureHasPermission()
        {
        }

        protected void EnsureHasMaintenancePermission()
        {
            bool hasAccess = _userContext.User.Role.CheckPermission(Permission.CanMaintenanceAccess);
            if (hasAccess is false)
            {
                throw new UnauthorizedAccessException(
                    "The current user does not have permission to maintenance access to categories."
                );
            }
        }

        protected void EnsureHasSelectPermission()
        {
            bool hasMaintenancePermission = _userContext.User.Role.CheckPermission(Permission.CanMaintenanceAccess);

            if (hasMaintenancePermission) return;


            if (string.IsNullOrEmpty(_queryContext.UserId))
            {
                throw new ArgumentNullException(nameof(_queryContext.UserId));
            }

            bool isSelfRequested = _userContext.User.Id == _queryContext.UserId;

            if (isSelfRequested) return;


            throw new UnauthorizedAccessException(
                "The current user does not have permission to maintenance access to facilities."
            );
        }
    }
}
#region

using System;
using System.Threading.Tasks;
using FacilityAccessService.Business.AccessScope.Actions;
using FacilityAccessService.Business.AccessScope.Services;
using FacilityAccessService.Business.UserScope.ValueObjects;
using FacilityAccessService.Domain.Secure.AccessScope.Interfaces;
using FacilityAccessService.Domain.Secure.CommonScope.Abstractions;
using FacilityAccessService.Domain.Secure.CommonScope.Context;

#endregion

namespace FacilityAccessService.Domain.Secure.AccessScope
{
    public class AccessCategoryServiceSecure : BaseServiceUserSecure, IAccessCategoryServiceSecure
    {
        private readonly IAccessCategoryService _accessCategory;


        public AccessCategoryServiceSecure(IAccessCategoryService accessCategory, IUserContext userContext)
            : base(userContext)
        {
            if (accessCategory is null) throw new ArgumentNullException(nameof(accessCategory));

            this._accessCategory = accessCategory;
        }


        public async Task GrantAccessAsync(GrantAccessCategoryModel grantAccessModel)
        {
            await _accessCategory.GrantAccessAsync(grantAccessModel);
        }

        public async Task RevokeAccessAsync(RevokeAccessCategoryModel revokeAccessModel)
        {
            await _accessCategory.RevokeAccessAsync(revokeAccessModel);
        }

        public async Task UpdateAccessAsync(UpdateAccessCategoryModel updateAccessModel)
        {
            await _accessCategory.UpdateAccessAsync(updateAccessModel);
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
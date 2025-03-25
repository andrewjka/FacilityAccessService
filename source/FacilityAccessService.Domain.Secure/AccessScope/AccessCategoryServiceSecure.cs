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
    public class AccessCategoryServiceSecure : BaseUserAuthorization, IAccessCategoryServiceSecure
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

        public async Task<UserCategory> GetAccessUserCategoryAsync(Specification<UserCategory> specification)
        {
            return await _accessCategory.GetAccessUserCategoryAsync(specification);
        }

        public async Task<ReadOnlyCollection<UserCategory>> GetAccessUserCategoriesAsync(
            Specification<UserCategory> specification
        )
        {
            return await _accessCategory.GetAccessUserCategoriesAsync(specification);
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
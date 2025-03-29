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
    public class AccessCategoryServiceSecure : BaseUserAuthorization, IAccessCategoryServiceSecure
    {
        private readonly IAccessCategoryService _accessCategory;

        private readonly IUserQueryContext _queryContext;


        public AccessCategoryServiceSecure(
            IAccessCategoryService accessCategory,
            IUserContext userContext,
            IUserQueryContext userQueryContext
        )
            : base(userContext)
        {
            if (accessCategory is null) throw new ArgumentNullException(nameof(accessCategory));
            if (userContext is null) throw new ArgumentNullException(nameof(userContext));
            if (userQueryContext is null) throw new ArgumentNullException(nameof(userQueryContext));


            this._accessCategory = accessCategory;
            this._queryContext = userQueryContext;
        }


        public async Task GrantAccessAsync(GrantAccessCategoryModel grantAccessModel)
        {
            EnsureHasMaintenancePermission();
            await _accessCategory.GrantAccessAsync(grantAccessModel);
        }

        public async Task RevokeAccessAsync(RevokeAccessCategoryModel revokeAccessModel)
        {
            EnsureHasMaintenancePermission();
            await _accessCategory.RevokeAccessAsync(revokeAccessModel);
        }

        public async Task UpdateAccessAsync(UpdateAccessCategoryModel updateAccessModel)
        {
            EnsureHasMaintenancePermission();
            await _accessCategory.UpdateAccessAsync(updateAccessModel);
        }

        public async Task<UserCategory> GetAccessAsync(Specification<UserCategory> specification)
        {
            EnsureHasSelectPermission();
            return await _accessCategory.GetAccessAsync(specification);
        }

        public async Task<ReadOnlyCollection<UserCategory>> GetAccessesAsync(
            Specification<UserCategory> specification
        )
        {
            EnsureHasSelectPermission();
            return await _accessCategory.GetAccessesAsync(specification);
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
                "The current user does not have permission to maintenance access to categories."
            );
        }
    }
}
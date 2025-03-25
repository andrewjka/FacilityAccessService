#region

using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FacilityAccessService.Business.AccessScope.Actions;
using FacilityAccessService.Business.AccessScope.Models;
using FacilityAccessService.Business.AccessScope.Services.Generic;
using FacilityAccessService.Business.CommonScope.Specification;

#endregion

namespace FacilityAccessService.Business.AccessScope.Services
{
    /// <inheritdoc/>
    public interface IAccessCategoryService
        : IAccessService<GrantAccessCategoryModel, RevokeAccessCategoryModel, UpdateAccessCategoryModel>
    {
        /// <summary>
        /// Get the access User to Category by specification.
        /// </summary>
        public Task<UserCategory> GetAccessUserCategoryAsync(
            Specification<UserCategory> specification
        );

        /// <summary>
        /// Get all access User to Category by specification.
        /// </summary>
        public Task<ReadOnlyCollection<UserCategory>> GetAccessUserCategoriesAsync(
            Specification<UserCategory> specification
        );
    }
}
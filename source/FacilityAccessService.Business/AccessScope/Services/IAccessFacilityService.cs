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
    public interface IAccessFacilityService
        : IAccessService<GrantAccessFacilityModel, RevokeAccessFacilityModel, UpdateAccessFacilityModel>
    {
        /// <summary>
        /// Get the access User to Facility by specification.
        /// </summary>
        public Task<UserFacility> GetAccessAsync(
            Specification<UserFacility> specification
        );

        /// <summary>
        /// Get all access User to Facility by specification.
        /// </summary>
        public Task<ReadOnlyCollection<UserFacility>> GetAccessesAsync(
            Specification<UserFacility> specification
        );
    }
}
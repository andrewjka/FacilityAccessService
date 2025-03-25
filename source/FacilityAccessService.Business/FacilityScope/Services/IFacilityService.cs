#region

using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FacilityAccessService.Business.CommonScope.Specification;
using FacilityAccessService.Business.FacilityScope.Actions;
using FacilityAccessService.Business.FacilityScope.Models;

#endregion

namespace FacilityAccessService.Business.FacilityScope.Services
{
    /// <summary>
    /// Describes the service for the main cases with the Facility entity.
    /// </summary>
    public interface IFacilityService
    {
        /// <summary>
        /// Creates a new Facility.
        /// </summary>
        public Task<Facility> CreateFacilityAsync(CreateFacilityModel createFacilityModel);

        /// <summary>
        /// Get the Facility by specification.
        /// </summary>
        public Task<Facility> GetFacilityAsync(Specification<Facility> specification);

        /// <summary>
        /// Get all Facilities by specification.
        /// </summary>
        public Task<ReadOnlyCollection<Facility>> GetFacilitiesAsync(Specification<Facility> specification);

        /// <summary>
        /// Updates the Facility.
        /// </summary>
        public Task<Facility> UpdateFacilityAsync(UpdateFacilityModel updateFacilityModel);

        /// <summary>
        /// Deletes the Facility.
        /// </summary>
        public Task DeleteFacilityAsync(DeleteFacilityModel deleteFacilityModel);
    }
}
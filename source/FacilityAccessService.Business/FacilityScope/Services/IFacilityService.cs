using System.Threading.Tasks;
using FacilityAccessService.Business.FacilityScope.Actions;
using FacilityAccessService.Business.FacilityScope.Models;

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
        /// Updates the Facility.
        /// </summary>
        public Task<Facility> UpdateFacilityAsync(UpdateFacilityModel updateFacilityModel);

        /// <summary>
        /// Deletes the Facility.
        /// </summary>
        public Task DeleteFacilityAsync(DeleteFacilityModel deleteFacilityModel);
    }
}
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
        public Task<Facility> CreateFacilityAsync(CreateFacilityModel createFacilityModel);

        public Task<Facility> UpdateFacilityAsync(UpdateFacilityModel updateFacilityModel);

        public Task DeleteFacilityAsync(DeleteFacilityModel deleteFacilityModel);
    }
}
using System.Threading.Tasks;
using FacilityAccessService.Business.FacilityScope.Actions;

namespace FacilityAccessService.Business.FacilityScope.Services
{
    /// <summary>
    /// Describes the service for the main cases with the Facility entity.
    /// </summary>
    public interface IFacilityService
    {
        public Task<Models.Facility> CreateObjectAsync(CreateFacilityModel createFacilityModel);

        public Task<Models.Facility> UpdateObjectAsync(UpdateFacilityModel updateFacilityModel);

        public Task DeleteObjectAsync(DeleteFacilityModel deleteFacilityModel);
    }
}
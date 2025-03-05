using System.Threading.Tasks;
using FacilityAccessService.Business.ObjectScope.Actions;

namespace FacilityAccessService.Business.ObjectScope.Services
{
    /// <summary>
    /// Describes the service for the main cases with the Object entity.
    /// </summary>
    public interface IObjectService
    {
        public Task<Models.Object> CreateObjectAsync(CreateObjectModel createObjectModel);

        public Task<Models.Object> UpdateObjectAsync(UpdateObjectModel updateObjectModel);

        public Task DeleteObjectAsync(DeleteObjectModel deleteObjectModel);
    }
}
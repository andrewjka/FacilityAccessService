using System.Threading.Tasks;
using FacilityAccessService.Business.Object.Actions;

namespace FacilityAccessService.Business.Object.Services
{
    /// <summary>
    /// Describes the service for the main cases with the Object entity.
    /// </summary>
    public interface IObjectService
    {
        public Task CreateObjectAsync(CreateObjectModel createObjectModel);

        public Task UpdateObjectAsync(UpdateObjectModel updateObjectModel);

        public Task DeleteObjectAsync(DeleteObjectModel deleteObjectModel);
    }
}
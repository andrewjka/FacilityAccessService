using System.Threading.Tasks;
using FacilityAccessService.Business.UserScope.Actions;

namespace FacilityAccessService.Business.UserScope.Services
{
    /// <summary>
    /// Describes the service for the main cases with the User entity.
    /// </summary>
    public interface IUserService
    {
        public Task<Models.User> RegistryUserAsync(RegistryUserModel registryUserModel);
    }
}
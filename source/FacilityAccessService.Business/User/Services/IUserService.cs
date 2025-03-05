using System.Threading.Tasks;
using FacilityAccessService.Business.User.Actions;
using FacilityAccessService.Business.User.Models;

namespace FacilityAccessService.Business.User.Services
{
    /// <summary>
    /// Describes the service for the main cases with the User entity.
    /// </summary>
    public interface IUserService
    {
        public Task<Models.User> RegistryUserAsync(RegistryUserModel registryUserModel);
    }
}
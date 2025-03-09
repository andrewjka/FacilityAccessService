using System.Threading.Tasks;
using FacilityAccessService.Business.UserScope.Actions;
using FacilityAccessService.Business.UserScope.Models;

namespace FacilityAccessService.Business.UserScope.Services
{
    /// <summary>
    /// Describes the service for the main cases with the User entity.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Registers a new User.
        /// </summary>
        public Task<User> RegistryUserAsync(RegistryUserModel registryUserModel);
    }
}
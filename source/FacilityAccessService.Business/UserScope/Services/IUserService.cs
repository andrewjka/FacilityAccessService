#region

using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FacilityAccessService.Business.CommonScope.Specification;
using FacilityAccessService.Business.UserScope.Actions;
using FacilityAccessService.Business.UserScope.Models;

#endregion

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

        /// <summary>
        /// Get the User by specification.
        /// </summary>
        public Task<User> GetUserAsync(Specification<User> specification);

        /// <summary>
        /// Get all Users by specification.
        /// </summary>
        public Task<ReadOnlyCollection<User>> GetUsersAsync(Specification<User> specification);
    }
}
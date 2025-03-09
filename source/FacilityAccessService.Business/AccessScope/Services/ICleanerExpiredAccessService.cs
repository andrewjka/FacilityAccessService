using System.Threading.Tasks;

namespace FacilityAccessService.Business.AccessScope.Services
{
    /// <summary>
    /// Describes a service for clear all expired access.
    /// </summary>
    public interface ICleanerExpiredAccessService
    {
        /// <summary>
        /// Clears all expired access.
        /// </summary>
        /// <returns></returns>
        public Task ClearExpiredAccessAsync();
    }
}
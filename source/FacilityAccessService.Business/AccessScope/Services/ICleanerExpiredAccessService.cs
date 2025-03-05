using System.Threading.Tasks;

namespace FacilityAccessService.Business.AccessScope.Services
{
    /// <summary>
    /// Describes a service for clear all expired access.
    /// </summary>
    public interface ICleanerExpiredAccessService
    {
        public Task ClearExpiredAccessAsync();
    }
}
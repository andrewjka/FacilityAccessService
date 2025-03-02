using System.Threading.Tasks;

namespace FacilityAccessService.Business.Access.Services
{
    /// <summary>
    /// Describes a service for clear all expired access.
    /// </summary>
    public interface ICleanerExpiredAccessService
    {
        public Task ClearExpiredAccessAsync();
    }
}
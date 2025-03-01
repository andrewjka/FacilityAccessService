using System.Threading.Tasks;

namespace FacilityAccessService.Business.Access.Services
{
    public interface ICleanerExpiredAccessService
    {
        public Task ClearExpiredAccessAsync();
    }
}
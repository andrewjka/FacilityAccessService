using System.Threading.Tasks;
using FacilityAccessService.Business.Common.Actions;

namespace FacilityAccessService.Business.Common.Services
{
    /// <summary>
    /// Describes a service for verifying userClient access to an object through a guard man.
    /// </summary>
    public interface IAccessControlService
    {
        public Task<bool> VerifyAccessAsync(VerifyAccessViaUserClientModel verifyAccessModel);
    }
}
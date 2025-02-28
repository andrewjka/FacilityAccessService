using FacilityAccessService.Business.Actions;
using FacilityAccessService.Business.Entities;

namespace FacilityAccessService.Business.IServices
{
    /// <summary>
    /// Describes a service for verifying userClient access to an object through a guard man.
    /// </summary>
    public interface IAccessControlService
    {
        public bool VerifyAccess(VerifyAccessViaUserClientModel verifyAccessModel);
    }
}
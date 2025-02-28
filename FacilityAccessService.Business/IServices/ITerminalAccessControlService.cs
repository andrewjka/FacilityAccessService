using FacilityAccessService.Business.Actions;
using FacilityAccessService.Business.Entities;

namespace FacilityAccessService.Business.IServices
{
    /// <summary>
    /// Describes a service for verifying userClient access to an object through a terminal.
    /// </summary>
    public interface ITerminalAccessControlService
    {
        public bool VerifyAccess(VerifyAccessViaTerminalModel verifyAccessModel);
    }
}
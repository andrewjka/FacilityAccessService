using System.Threading.Tasks;
using FacilityAccessService.Business.Common.Actions;

namespace FacilityAccessService.Business.Common.Services
{
    /// <summary>
    /// Describes a service for verifying userClient access to an object through a terminal.
    /// </summary>
    public interface ITerminalAccessControlService
    {
        public Task<bool> VerifyAccessAsync(VerifyAccessViaTerminalModel verifyAccessModel);
    }
}
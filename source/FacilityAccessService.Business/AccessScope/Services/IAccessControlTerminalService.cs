using FacilityAccessService.Business.AccessScope.Services.Generic;
using FacilityAccessService.Business.TerminalScope.Models;

namespace FacilityAccessService.Business.AccessScope.Services
{
    /// <inheritdoc/>
    public interface IAccessControlTerminalService : IAccessControlService<TerminalScope.Models.Terminal>
    {
        
    }
}
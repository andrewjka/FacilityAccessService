using FacilityAccessService.Business.Access.Actions.Generic;
using FacilityAccessService.Business.Terminal.Models;

namespace FacilityAccessService.Business.Access.Actions
{
    /// <inheritdoc/>
    public record VerifyAccessViaTerminalModel : VerifyAccessModel<TerminalClient>
    {
        
    }
}
using System;
using FacilityAccessService.Business.Access.Actions.Generic;
using FacilityAccessService.Business.Terminal.Models;

namespace FacilityAccessService.Business.Access.Actions
{
    /// <inheritdoc/>
    public record VerifyAccessViaTerminalModel(
        Guid UserId,
        string TokenTerminal,
        Guid ObjectId
    ) : VerifyAccessModel<TerminalClient>;
}
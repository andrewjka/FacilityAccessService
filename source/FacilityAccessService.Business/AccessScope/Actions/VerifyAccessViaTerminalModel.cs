using System;
using FacilityAccessService.Business.AccessScope.Actions.Generic;
using FacilityAccessService.Business.TerminalScope.Models;

namespace FacilityAccessService.Business.AccessScope.Actions
{
    /// <inheritdoc/>
    public record VerifyAccessViaTerminalModel(string TokenTerminal) : VerifyAccessModel<TerminalScope.Models.Terminal>;
}
using System;
using FacilityAccessService.Business.AccessScope.Actions.Abstractions;
using FacilityAccessService.Business.TerminalScope.Models;

namespace FacilityAccessService.Business.AccessScope.Actions
{
    /// <inheritdoc/>
    public record VerifyAccessViaTerminalModel(string TokenTerminal) : VerifyAccessModel;
}
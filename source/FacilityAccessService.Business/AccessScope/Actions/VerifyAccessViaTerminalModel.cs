using FacilityAccessService.Business.AccessScope.Actions.Abstractions;
using FacilityAccessService.Business.TerminalScope.ValueObjects;

namespace FacilityAccessService.Business.AccessScope.Actions
{
    /// <inheritdoc/>
    public record VerifyAccessViaTerminalModel(TerminalToken TokenTerminal) : VerifyAccessModel;
}
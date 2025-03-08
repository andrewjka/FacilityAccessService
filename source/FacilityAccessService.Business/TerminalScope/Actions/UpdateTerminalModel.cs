using System;

namespace FacilityAccessService.Business.TerminalScope.Actions
{
    /// <summary>
    /// The action model for update the terminal.
    /// </summary>
    public record UpdateTerminalModel(
        Guid TerminalId,
        string Name,
        DateOnly? ExpiredTokenOn
    );
}
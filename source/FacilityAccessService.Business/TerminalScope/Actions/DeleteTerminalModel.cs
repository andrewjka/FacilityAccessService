using System;

namespace FacilityAccessService.Business.TerminalScope.Actions
{
    /// <summary>
    /// The action model for delete the terminal.
    /// </summary>
    public record DeleteTerminalModel(Guid TerminalId);
}
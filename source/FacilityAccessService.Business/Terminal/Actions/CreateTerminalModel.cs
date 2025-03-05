using System;

namespace FacilityAccessService.Business.Terminal.Actions
{
    /// <summary>
    /// The action model for create a terminal.
    /// </summary>
    public record CreateTerminalModel(
        string Name,
        string Description,
        DateOnly ExpiredTokenOn
    );
}
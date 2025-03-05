using System;

namespace FacilityAccessService.Business.Terminal.Actions
{
    /// <summary>
    /// The action model for update the terminal.
    /// </summary>
    public record UpdateTerminalModel(
        Guid Uid,
        string Name,
        string Description,
        DateOnly ExpiredTokenOn
    );
}
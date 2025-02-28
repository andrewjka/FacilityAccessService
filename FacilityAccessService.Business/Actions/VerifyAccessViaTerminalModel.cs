using System;

namespace FacilityAccessService.Business.Actions
{
    /// <summary>
    /// Describes a model for verifying user access to a facility via a terminal.
    /// </summary>
    /// <param name="TerminalToken">api terminal token</param>
    /// <param name="UserClientToken">client session token</param>
    /// <param name="objectId">facility identifier</param>
    public record VerifyAccessViaTerminalModel(string TerminalToken, string UserClientToken, Guid objectId);
}
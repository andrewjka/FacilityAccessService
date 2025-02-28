using System;

namespace FacilityAccessService.Business.Actions
{
    /// <summary>
    /// Describes a model for verifying user access to a facility via a guard man.
    /// </summary>
    /// <param name="GuardClientToken">guard man session token</param>
    /// <param name="UserClientToken">client session token</param>
    /// <param name="objectId">facility identifier</param>
    public record VerifyAccessViaUserClientModel(string GuardClientToken, string UserClientToken, Guid objectId);
}
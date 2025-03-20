using System;

namespace FacilityAccessService.Business.AccessScope.Actions.Abstractions
{
    /// <summary>
    /// The action model for verify access via specific access checker.
    /// </summary>
    public record VerifyAccessModel(string UserId, Guid FacilityId);
}
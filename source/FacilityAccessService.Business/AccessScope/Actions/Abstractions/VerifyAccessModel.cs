using System;

namespace FacilityAccessService.Business.AccessScope.Actions.Abstractions
{
    /// <summary>
    /// The action model for verify access via specific access checker.
    /// </summary>
    public abstract record VerifyAccessModel(string UserId, Guid FacilityId);
}
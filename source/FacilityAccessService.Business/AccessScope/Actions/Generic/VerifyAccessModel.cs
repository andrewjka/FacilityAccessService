using System;

namespace FacilityAccessService.Business.AccessScope.Actions.Generic
{
    /// <summary>
    /// The action model for verify access via specific access checker.
    /// </summary>
    public abstract record VerifyAccessModel<TAccessChecker> where TAccessChecker : class
    {
        public Guid UserId { get; init; }
        public Guid ObjectId { get; init; }
    }
}
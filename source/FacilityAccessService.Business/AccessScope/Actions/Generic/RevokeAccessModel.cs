using System;
using FacilityAccessService.Business.FacilityScope.Models;

namespace FacilityAccessService.Business.AccessScope.Actions.Generic
{
    /// <summary>
    /// The action model for revoke access to accessed resource.
    /// </summary>
    public abstract record RevokeAccessModel<TAccessedResource> where TAccessedResource : IAccessedResource
    {
        public Guid UserId { get; init; }
    }
}
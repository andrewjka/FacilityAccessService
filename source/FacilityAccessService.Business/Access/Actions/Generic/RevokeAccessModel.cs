using System;
using FacilityAccessService.Business.Object.Models;

namespace FacilityAccessService.Business.Access.Actions.Generic
{
    /// <summary>
    /// The action model for revoke access to accessed resource.
    /// </summary>
    public abstract record RevokeAccessModel<TAccessedResource> where TAccessedResource : IAccessedResouce
    {
        public Guid UserId { get; init; }
    }
}
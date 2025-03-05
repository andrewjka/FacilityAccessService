using System;
using FacilityAccessService.Business.Common.ValueObjects;
using FacilityAccessService.Business.Object.Models;

namespace FacilityAccessService.Business.Access.Actions.Generic
{
    /// <summary>
    /// The action model for grant access to accessed resource.
    /// </summary>
    public abstract record GrantAccessModel<TAccessedResource> where TAccessedResource : IAccessedResouce
    {
        public Guid UserId { get; init; }
        public AccessPeriod AccessPeriod { get; init; }
    }
}
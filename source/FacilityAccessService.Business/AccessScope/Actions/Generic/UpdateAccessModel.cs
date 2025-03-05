using System;
using FacilityAccessService.Business.AccessScope.ValueObjects;
using FacilityAccessService.Business.ObjectScope.Models;

namespace FacilityAccessService.Business.AccessScope.Actions.Generic
{
    /// <summary>
    /// The action model for update access to accessed resource.
    /// </summary>
    public abstract record UpdateAccessModel<TAccessedResource> where TAccessedResource: IAccessedResource
    {
        public Guid UserId { get; init; }
        public AccessPeriod AccessPeriod { get; init; }
    }
}
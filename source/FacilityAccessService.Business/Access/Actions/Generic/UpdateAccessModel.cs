using System;
using FacilityAccessService.Business.Common.ValueObjects;
using FacilityAccessService.Business.Object.Models;

namespace FacilityAccessService.Business.Access.Actions.Generic
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
using System;
using FacilityAccessService.Business.Common.ValueObjects;

namespace FacilityAccessService.Business.Access.Actions.Generic
{
    /// <summary>
    /// The action model for grant access through specific access model.
    /// </summary>
    public abstract record GrantAccessModel<TAccessModel> where TAccessModel : class
    {
        public Guid UserId { get; init; }
        public AccessPeriod AccessPeriod { get; init; }
    }
}
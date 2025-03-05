using System;
using FacilityAccessService.Business.Common.ValueObjects;

namespace FacilityAccessService.Business.Access.Actions.Generic
{
    /// <summary>
    /// The action model for update a specific access model.
    /// </summary>
    public abstract record UpdateAccessModel<TAccessModel> where TAccessModel: class
    {
        public Guid UserId { get; init; }
        public AccessPeriod AccessPeriod { get; init; }
    }
}
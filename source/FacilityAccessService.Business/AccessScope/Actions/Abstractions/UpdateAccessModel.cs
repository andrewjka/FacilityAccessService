using FacilityAccessService.Business.AccessScope.ValueObjects;

namespace FacilityAccessService.Business.AccessScope.Actions.Abstractions
{
    /// <summary>
    /// The action model for update access to accessed resource.
    /// </summary>
    public abstract record UpdateAccessModel
    {
        public string UserId { get; init; }
        public AccessPeriod AccessPeriod { get; init; }
    }
}
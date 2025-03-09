using FacilityAccessService.Business.AccessScope.ValueObjects;

namespace FacilityAccessService.Business.AccessScope.Actions.Abstractions
{
    /// <summary>
    /// The action model for grant access to accessed resource.
    /// </summary>
    public abstract record GrantAccessModel
    {
        public string UserId { get; init; }
        public AccessPeriod AccessPeriod { get; init; }
    }
}
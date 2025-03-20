using FacilityAccessService.Business.AccessScope.ValueObjects;

namespace FacilityAccessService.Business.AccessScope.Actions.Abstractions
{
    /// <summary>
    /// The action model for grant access to accessed resource.
    /// </summary>
    public abstract record GrantAccessModel(string UserId, AccessPeriod AccessPeriod);
}
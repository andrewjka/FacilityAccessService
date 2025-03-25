#region

using FacilityAccessService.Business.AccessScope.ValueObjects;

#endregion

namespace FacilityAccessService.Business.AccessScope.Actions.Abstractions
{
    /// <summary>
    /// The action model for grant access to accessed resource.
    /// </summary>
    public abstract record GrantAccessModel(string UserId, AccessPeriod AccessPeriod);
}
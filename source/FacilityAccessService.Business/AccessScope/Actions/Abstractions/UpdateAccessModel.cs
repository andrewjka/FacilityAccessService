#region

using FacilityAccessService.Business.AccessScope.ValueObjects;

#endregion

namespace FacilityAccessService.Business.AccessScope.Actions.Abstractions
{
    /// <summary>
    /// The action model for update access to accessed resource.
    /// </summary>
    public abstract record UpdateAccessModel(string UserId, AccessPeriod AccessPeriod);
}
namespace FacilityAccessService.Business.AccessScope.Actions.Abstractions
{
    /// <summary>
    /// The action model for revoke access to accessed resource.
    /// </summary>
    public abstract record RevokeAccessModel(string UserId);
}
namespace FacilityAccessService.Business.Access.Actions.Generic
{
    /// <summary>
    /// The action model for revoke access through specific access model.
    /// </summary>
    public abstract record RevokeAccessModel<TAccessModel> where TAccessModel: class
    {
        
    }
}
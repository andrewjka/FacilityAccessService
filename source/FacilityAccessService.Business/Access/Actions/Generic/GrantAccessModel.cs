namespace FacilityAccessService.Business.Access.Actions.Generic
{
    /// <summary>
    /// The action model for grant access through specific access model.
    /// </summary>
    public abstract record GrantAccessModel<TAccessModel> where TAccessModel: class
    {
        
    }
}
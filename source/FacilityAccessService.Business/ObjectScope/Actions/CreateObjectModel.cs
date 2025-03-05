namespace FacilityAccessService.Business.ObjectScope.Actions
{
    /// <summary>
    /// The action model for create an Object
    /// </summary>
    public record CreateObjectModel(
        string Name,
        string Description
    );
}
namespace FacilityAccessService.Business.FacilityScope.Actions
{
    /// <summary>
    /// The action model for create an Facility
    /// </summary>
    public record CreateFacilityModel(
        string Name,
        string Description
    );
}
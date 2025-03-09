namespace FacilityAccessService.Business.FacilityScope.Actions
{
    /// <summary>
    /// The action model for creating a Facility
    /// </summary>
    public record CreateFacilityModel(
        string Name,
        string Description
    );
}
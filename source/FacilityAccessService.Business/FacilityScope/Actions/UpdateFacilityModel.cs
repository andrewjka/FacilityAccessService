using System;

namespace FacilityAccessService.Business.FacilityScope.Actions
{
    /// <summary>
    /// The action model for update the Facility
    /// </summary>
    public record UpdateFacilityModel(
        Guid FacilityId,
        string Name,
        string Description
    );
}
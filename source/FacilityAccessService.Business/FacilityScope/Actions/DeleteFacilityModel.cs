using System;

namespace FacilityAccessService.Business.FacilityScope.Actions
{
    /// <summary>
    /// The action model for delete the Facility
    /// </summary>
    public record DeleteFacilityModel(
        Guid ObjectId
    );
}
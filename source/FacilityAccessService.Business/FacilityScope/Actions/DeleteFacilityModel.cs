using System;

namespace FacilityAccessService.Business.FacilityScope.Actions
{
    /// <summary>
    /// The action model for deleting the Facility
    /// </summary>
    public record DeleteFacilityModel(Guid FacilityId);
}
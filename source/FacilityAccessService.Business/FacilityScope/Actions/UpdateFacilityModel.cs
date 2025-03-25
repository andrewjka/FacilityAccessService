#region

using System;

#endregion

namespace FacilityAccessService.Business.FacilityScope.Actions
{
    /// <summary>
    /// The action model for updating the Facility.
    /// </summary>
    public record UpdateFacilityModel(
        Guid FacilityId,
        string Name,
        string Description
    );
}
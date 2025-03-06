using System;
using FacilityAccessService.Business.AccessScope.Actions.Generic;

namespace FacilityAccessService.Business.AccessScope.Actions
{
    /// <inheritdoc/>
    public record GrantAccessFacilityModel(Guid ObjectId) : GrantAccessModel<FacilityScope.Models.Facility>;
}
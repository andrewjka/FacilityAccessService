using System;
using FacilityAccessService.Business.AccessScope.Actions.Generic;

namespace FacilityAccessService.Business.AccessScope.Actions
{
    /// <inheritdoc/>
    public record RevokeAccessFacilityModel(Guid ObjectId) : RevokeAccessModel<FacilityScope.Models.Facility>;
}
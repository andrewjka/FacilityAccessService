using System;
using FacilityAccessService.Business.AccessScope.Actions.Generic;

namespace FacilityAccessService.Business.AccessScope.Actions
{
    /// <inheritdoc/>
    public record UpdateAccessFacilityModel(Guid ObjectId) : UpdateAccessModel<FacilityScope.Models.Facility>;
}
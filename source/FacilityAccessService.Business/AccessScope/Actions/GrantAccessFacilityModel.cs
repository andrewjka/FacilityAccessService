using System;
using FacilityAccessService.Business.AccessScope.Actions.Abstractions;

namespace FacilityAccessService.Business.AccessScope.Actions
{
    /// <inheritdoc/>
    public record GrantAccessFacilityModel(Guid ObjectId) : GrantAccessModel;
}
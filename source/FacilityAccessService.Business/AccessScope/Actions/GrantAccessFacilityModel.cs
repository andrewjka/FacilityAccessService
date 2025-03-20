using System;
using FacilityAccessService.Business.AccessScope.Actions.Abstractions;
using FacilityAccessService.Business.AccessScope.ValueObjects;

namespace FacilityAccessService.Business.AccessScope.Actions
{
    /// <inheritdoc/>
    public record GrantAccessFacilityModel(Guid FacilityId, string UserId, AccessPeriod AccessPeriod)
        : GrantAccessModel(
            UserId: UserId,
            AccessPeriod: AccessPeriod
        );
}
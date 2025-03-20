using System;
using FacilityAccessService.Business.AccessScope.Actions.Abstractions;
using FacilityAccessService.Business.AccessScope.ValueObjects;

namespace FacilityAccessService.Business.AccessScope.Actions
{
    /// <inheritdoc/>
    public record UpdateAccessCategoryModel(Guid CategoryId, string UserId, AccessPeriod AccessPeriod)
        : UpdateAccessModel(
            UserId: UserId,
            AccessPeriod: AccessPeriod
        );
}
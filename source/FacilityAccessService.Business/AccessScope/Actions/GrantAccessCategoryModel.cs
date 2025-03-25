#region

using System;
using FacilityAccessService.Business.AccessScope.Actions.Abstractions;
using FacilityAccessService.Business.AccessScope.ValueObjects;

#endregion

namespace FacilityAccessService.Business.AccessScope.Actions
{
    /// <inheritdoc/>
    public record GrantAccessCategoryModel(Guid CategoryId, string UserId, AccessPeriod AccessPeriod)
        : GrantAccessModel(
            UserId: UserId,
            AccessPeriod: AccessPeriod
        );
}
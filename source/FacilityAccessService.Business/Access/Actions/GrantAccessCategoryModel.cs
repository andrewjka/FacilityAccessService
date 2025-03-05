using System;
using FacilityAccessService.Business.Access.Actions.Generic;
using FacilityAccessService.Business.Common.ValueObjects;
using FacilityAccessService.Business.Object.Models;

namespace FacilityAccessService.Business.Access.Actions
{
    /// <inheritdoc/>
    public record GrantAccessCategoryModel(
        Guid UserId,
        Guid CategoryId,
        AccessPeriod AccessPeriod
    ) : GrantAccessModel<Category>;
}
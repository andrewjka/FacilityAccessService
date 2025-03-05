using System;
using FacilityAccessService.Business.Access.Actions.Generic;
using FacilityAccessService.Business.Common.ValueObjects;
using FacilityAccessService.Business.Object.Models;

namespace FacilityAccessService.Business.Access.Actions
{
    /// <inheritdoc/>
    public record UpdateAccessCategoryModel(
        Guid UserId,
        Guid CategoryId,
        AccessPeriod AccessPeriod
    ) : UpdateAccessModel<Category>;
}
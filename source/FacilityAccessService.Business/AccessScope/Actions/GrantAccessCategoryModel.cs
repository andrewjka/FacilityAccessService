using System;
using FacilityAccessService.Business.AccessScope.Actions.Generic;
using FacilityAccessService.Business.FacilityScope.Models;

namespace FacilityAccessService.Business.AccessScope.Actions
{
    /// <inheritdoc/>
    public record GrantAccessCategoryModel(Guid CategoryId) : GrantAccessModel<Category>;
}
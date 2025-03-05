using System;
using FacilityAccessService.Business.Access.Actions.Generic;
using FacilityAccessService.Business.Object.Models;

namespace FacilityAccessService.Business.Access.Actions
{
    /// <inheritdoc/>
    public record GrantAccessCategoryModel(Guid CategoryId) : GrantAccessModel<Category>;
}
using System;
using FacilityAccessService.Business.AccessScope.Actions.Generic;
using FacilityAccessService.Business.ObjectScope.Models;

namespace FacilityAccessService.Business.AccessScope.Actions
{
    /// <inheritdoc/>
    public record RevokeAccessCategoryModel(Guid CategoryId) : RevokeAccessModel<Category>;
}
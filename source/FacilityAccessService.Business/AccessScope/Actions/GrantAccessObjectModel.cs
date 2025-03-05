using System;
using FacilityAccessService.Business.AccessScope.Actions.Generic;

namespace FacilityAccessService.Business.AccessScope.Actions
{
    /// <inheritdoc/>
    public record GrantAccessObjectModel(Guid ObjectId) : GrantAccessModel<ObjectScope.Models.Object>;
}
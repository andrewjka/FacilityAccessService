using System;
using FacilityAccessService.Business.Access.Actions.Generic;

namespace FacilityAccessService.Business.Access.Actions
{
    /// <inheritdoc/>
    public record GrantAccessObjectModel(Guid ObjectId) : GrantAccessModel<Object.Models.Object>;
}
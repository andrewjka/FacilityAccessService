using System;
using FacilityAccessService.Business.AccessScope.Actions.Generic;

namespace FacilityAccessService.Business.AccessScope.Actions
{
    /// <inheritdoc/>
    public record UpdateAccessObjectModel(Guid ObjectId) : UpdateAccessModel<ObjectScope.Models.Object>;
}
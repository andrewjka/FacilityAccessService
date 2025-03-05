using System;
using FacilityAccessService.Business.Access.Actions.Generic;
using FacilityAccessService.Business.Common.ValueObjects;

namespace FacilityAccessService.Business.Access.Actions
{
    /// <inheritdoc/>
    public record UpdateAccessObjectModel(Guid ObjectId) : UpdateAccessModel<Object.Models.Object>;
}
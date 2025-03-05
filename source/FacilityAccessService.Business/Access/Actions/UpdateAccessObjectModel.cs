using System;
using FacilityAccessService.Business.Access.Actions.Generic;
using FacilityAccessService.Business.Common.ValueObjects;

namespace FacilityAccessService.Business.Access.Actions
{
    /// <inheritdoc/>
    public record UpdateAccessObjectModel(
        Guid UserId,
        Guid ObjectId,
        AccessPeriod AccessPeriod
    ) : UpdateAccessModel<Object.Models.Object>;
}
using System;
using FacilityAccessService.Business.Access.Actions.Generic;
using FacilityAccessService.Business.Common.ValueObjects;

namespace FacilityAccessService.Business.Access.Actions
{
    /// <inheritdoc/>
    public record GrantAccessObjectModel(
        Guid UserId,
        Guid ObjectId,
        AccessPeriod AccessPeriod
    ) : GrantAccessModel<Object.Models.Object>;
}
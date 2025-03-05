using System;
using FacilityAccessService.Business.Access.Actions.Generic;

namespace FacilityAccessService.Business.Access.Actions
{
    /// <inheritdoc/>
    public record RevokeAccessObjectModel(
        Guid UserId,
        Guid ObjectId
    ) : RevokeAccessModel<Object.Models.Object>;
}
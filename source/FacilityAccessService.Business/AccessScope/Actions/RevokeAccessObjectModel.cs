using System;
using FacilityAccessService.Business.AccessScope.Actions.Generic;

namespace FacilityAccessService.Business.AccessScope.Actions
{
    /// <inheritdoc/>
    public record RevokeAccessObjectModel(Guid ObjectId) : RevokeAccessModel<ObjectScope.Models.Object>;
}
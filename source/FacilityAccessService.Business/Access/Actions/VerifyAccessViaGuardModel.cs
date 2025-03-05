using System;
using FacilityAccessService.Business.Access.Actions.Generic;
using FacilityAccessService.Business.User.Models;

namespace FacilityAccessService.Business.Access.Actions
{
    /// <inheritdoc/>
    public record VerifyAccessViaGuardModel(
        Guid UserId,
        Guid GuarderId,
        Guid ObjectId
    ) : VerifyAccessModel<UserClient>;
}
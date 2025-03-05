using System;
using FacilityAccessService.Business.Access.Actions.Generic;

namespace FacilityAccessService.Business.Access.Actions
{
    /// <inheritdoc/>
    public record VerifyAccessViaGuardModel(Guid GuarderId) : VerifyAccessModel<User.Models.User>;
}
using System;
using FacilityAccessService.Business.AccessScope.Actions.Generic;

namespace FacilityAccessService.Business.AccessScope.Actions
{
    /// <inheritdoc/>
    public record VerifyAccessViaGuardModel(Guid GuarderId) : VerifyAccessModel<UserScope.Models.User>;
}
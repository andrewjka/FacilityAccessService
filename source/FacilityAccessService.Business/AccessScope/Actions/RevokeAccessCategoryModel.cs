using System;
using FacilityAccessService.Business.AccessScope.Actions.Abstractions;

namespace FacilityAccessService.Business.AccessScope.Actions
{
    /// <inheritdoc/>
    public record RevokeAccessCategoryModel(Guid CategoryId, string UserId) : RevokeAccessModel(UserId);
}
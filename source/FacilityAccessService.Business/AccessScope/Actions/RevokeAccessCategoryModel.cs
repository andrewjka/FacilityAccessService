#region

using System;
using FacilityAccessService.Business.AccessScope.Actions.Abstractions;

#endregion

namespace FacilityAccessService.Business.AccessScope.Actions
{
    /// <inheritdoc/>
    public record RevokeAccessCategoryModel(Guid CategoryId, string UserId) : RevokeAccessModel(UserId);
}
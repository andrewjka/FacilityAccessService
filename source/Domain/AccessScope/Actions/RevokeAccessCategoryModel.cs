#region

using System;
using Domain.AccessScope.Actions;

#endregion

namespace Domain.AccessScope.Actions;

/// <inheritdoc />
public record RevokeAccessCategoryModel(Guid CategoryId, string UserId) : RevokeAccessModel(UserId);
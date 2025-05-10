#region

using System;
using Domain.AccessScope.Actions.Abstractions;

#endregion

namespace Domain.AccessScope.Actions;

/// <inheritdoc />
public record RevokeAccessCategoryModel(Guid CategoryId, string UserId) : RevokeAccessModel(UserId);
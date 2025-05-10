#region

using System;
using Domain.AccessScope.Actions.Abstractions;
using Domain.AccessScope.ValueObjects;

#endregion

namespace Domain.AccessScope.Actions;

/// <inheritdoc />
public record GrantAccessCategoryModel(Guid CategoryId, string UserId, AccessPeriod AccessPeriod)
    : GrantAccessModel(
        UserId,
        AccessPeriod
    );
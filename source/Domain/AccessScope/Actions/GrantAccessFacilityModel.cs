#region

using System;
using Domain.AccessScope.Actions;
using Domain.AccessScope.ValueObjects;

#endregion

namespace Domain.AccessScope.Actions;

/// <inheritdoc />
public record GrantAccessFacilityModel(Guid FacilityId, string UserId, AccessPeriod AccessPeriod)
    : GrantAccessModel(
        UserId,
        AccessPeriod
    );
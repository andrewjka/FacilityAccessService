#region

using System;
using Domain.AccessScope.Actions;
using Domain.AccessScope.ValueObjects;

#endregion

namespace Domain.AccessScope.Actions;

/// <inheritdoc />
public record UpdateAccessFacilityModel(Guid FacilityId, string UserId, AccessPeriod AccessPeriod)
    : UpdateAccessModel(
        UserId,
        AccessPeriod
    );
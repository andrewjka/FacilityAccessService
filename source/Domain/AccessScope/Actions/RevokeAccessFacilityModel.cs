#region

using System;
using Domain.AccessScope.Actions.Abstractions;

#endregion

namespace Domain.AccessScope.Actions;

/// <inheritdoc />
public record RevokeAccessFacilityModel(Guid FacilityId, string UserId) : RevokeAccessModel(UserId);
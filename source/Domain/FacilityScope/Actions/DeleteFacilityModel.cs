#region

using System;

#endregion

namespace Domain.FacilityScope.Actions;

/// <summary>
///     The action model for deleting the Facility
/// </summary>
public record DeleteFacilityModel(Guid FacilityId);
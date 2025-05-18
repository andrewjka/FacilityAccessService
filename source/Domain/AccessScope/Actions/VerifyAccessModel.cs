#region

using System;
using Domain.AccessScope.Models;

#endregion

namespace Domain.AccessScope.Actions;

/// <summary>
///     The action model for verify access via specific access checker.
/// </summary>
public record VerifyAccessModel(Guid FacilityId, string PassToken);
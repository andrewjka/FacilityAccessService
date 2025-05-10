#region

using Domain.AccessScope.ValueObjects;

#endregion

namespace Domain.AccessScope.Actions.Abstractions;

/// <summary>
///     The action model for update access to accessed resource.
/// </summary>
public abstract record UpdateAccessModel(string UserId, AccessPeriod AccessPeriod);
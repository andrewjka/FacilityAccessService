#region

using Domain.AccessScope.ValueObjects;

#endregion

namespace Domain.AccessScope.Actions;

/// <summary>
///     The action model for grant access to accessed resource.
/// </summary>
public abstract record GrantAccessModel(string UserId, AccessPeriod AccessPeriod);
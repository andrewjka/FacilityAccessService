namespace Domain.AccessScope.Actions;

/// <summary>
///     The action model for revoke access to accessed resource.
/// </summary>
public abstract record RevokeAccessModel(string UserId);
using Domain.UserScope.ValueObjects;

namespace Domain.UserScope.Actions;

/// <summary>
///     The action model for user registration.
/// </summary>
public record RegistryUserModel(string Email, string Password, Role role);
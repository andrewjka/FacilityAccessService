#region

using Domain.UserScope.ValueObjects;

#endregion

namespace Domain.UserScope.Models;

/// <summary>
///     Describes a user in the access control system.
/// </summary>
public class User
{
    public User(string externalUserId, Role role = null)
    {
        Id = externalUserId;
        Role = role ?? Role.Guest;
    }

    public string Id { get; private set; }
    public Role Role { get; private set; }

    public void ChangeRole(Role role)
    {
        Role = role;
    }
}
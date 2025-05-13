#region

using System;
using Domain.UserScope.ValueObjects;

#endregion

namespace Domain.UserScope.Models;

/// <summary>
///     Describes a user in the access control system.
/// </summary>
public class User
{
    public string Id { get; private set; }
    public Role Role { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }

    public User(string id, string email, string password, Role role = null)
    {
        Id = id;
        Role = role ?? Role.Guest;
        Email = email;
        Password = password;
    }

    public User(string email, string password, Role role = null)
    {
        Id = Guid.NewGuid().ToString();
        Role = role ?? Role.Guest;
        Email = email;
        Password = password;
    }

    public void ChangeRole(Role role)
    {
        Role = role;
    }

    public void ChangeEmail(string email)
    {
        Email = email;
    }

    public void ChangePassword(string password)
    {
        Password = password;
    }
}
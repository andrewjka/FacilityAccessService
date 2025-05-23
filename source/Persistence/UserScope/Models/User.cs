using Domain.UserScope.ValueObjects;

namespace Persistence.UserScope.Models;

public class User
{
    public string Id { get; set; }
    public Role Role { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
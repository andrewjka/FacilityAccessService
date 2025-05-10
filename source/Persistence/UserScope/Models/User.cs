using Domain.UserScope.ValueObjects;

namespace Persistence.UserScope.Models;

public class User
{
    public string Id { get; set; }
    public Role Role { get; set; }
}
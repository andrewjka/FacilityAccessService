using Domain.CommonScope.ValueObjects;
using Persistence.UserScope.Models;

namespace Persistence.AuthScope.Models;

public class RefreshToken
{
    public string UserId { get; set; }
    public Token512Bit Token { get; set; }
    
    
    public User User { get; set; }
}
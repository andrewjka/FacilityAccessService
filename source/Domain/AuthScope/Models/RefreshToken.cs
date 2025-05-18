using Domain.CommonScope.ValueObjects;

namespace Domain.AuthScope.Models;

public class RefreshToken
{
    public string UserId { get; private set; }
    public Token512Bit Token { get; private set; }

    
    public RefreshToken(string userId, Token512Bit token)
    {
        UserId = userId;
        Token = token;
    }
}
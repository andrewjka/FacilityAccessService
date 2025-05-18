using System;

namespace Domain.AccessScope.Models;

public class PassToken
{
    public string UserId { get; private set; }
    public DateTime ExpiresOn { get; private set; }


    public PassToken(string userId, DateTime expiresOn)
    {
        this.UserId = userId;
        this.ExpiresOn = expiresOn;
    }
}
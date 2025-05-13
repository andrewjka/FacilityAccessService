using System;

namespace Domain.AccessScope.Models;

public class PassToken
{
    public Guid Id { get; init; }
    public string UserId { get; private set; }
    public DateTime ExpiresOn { get; private set; }


    public PassToken(string userId, DateTime expiresOn)
    {
        this.Id = Guid.NewGuid();
        this.UserId = userId;
        this.ExpiresOn = expiresOn;
    }
}
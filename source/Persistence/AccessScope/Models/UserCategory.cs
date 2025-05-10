using System;
using Domain.AccessScope.ValueObjects;
using Persistence.FacilityScope.Models;
using Persistence.UserScope.Models;

namespace Persistence.AccessScope.Models;

public class UserCategory
{
    public string UserId { get; set; }
    public Guid CategoryId { get; set; }
    public AccessPeriod AccessPeriod { get; set; }


    public User User { get; set; }
    public Category Category { get; set; }
}
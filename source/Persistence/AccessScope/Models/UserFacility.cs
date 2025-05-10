using System;
using Domain.AccessScope.ValueObjects;
using Persistence.FacilityScope.Models;
using Persistence.UserScope.Models;

namespace Persistence.AccessScope.Models;

public class UserFacility
{
    public string UserId { get; set; }
    public Guid FacilityId { get; set; }
    public AccessPeriod AccessPeriod { get; set; }

    public User User { get; set; }
    public Facility Facility { get; set; }
}
using System;
using FacilityAccessService.Business.AccessScope.ValueObjects;
using FacilityAccessService.Persistence.FacilityScope.Models;
using FacilityAccessService.Persistence.UserScope.Models;

namespace FacilityAccessService.Persistence.AccessScope.Models
{
    public class UserFacility
    {
        public string UserId { get; set; }
        public Guid FacilityId { get; set; }
        public AccessPeriod AccessPeriod { get; set; }

        public User User { get; set; }
        public Facility Facility { get; set; }
    }
}
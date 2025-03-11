using System;
using FacilityAccessService.Business.AccessScope.ValueObjects;
using FacilityAccessService.Persistence.FacilityScope.Models;
using FacilityAccessService.Persistence.UserScope.Models;

namespace FacilityAccessService.Persistence.AccessScope.Models
{
    public class UserCategory
    {
        public string UserId { get; set; }
        public Guid CategoryId { get; set; }
        public AccessPeriod AccessPeriod { get; set; }


        public User User { get; set; }
        public Category Category { get; set; }
    }
}
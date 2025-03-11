using System;
using FacilityAccessService.Business.AccessScope.ValueObjects;
using FacilityAccessService.Business.CommonScope.Models;

namespace FacilityAccessService.Business.AccessScope.Models
{
    public class UserFacility
    {
        public string UserId { get; private set; }
        public Guid FacilityId { get; private set; }
        public AccessPeriod AccessPeriod { get; private set; }


        public UserFacility(
            string userId,
            Guid facilityId,
            AccessPeriod accessPeriod
        ) : base()
        {
            this.UserId = userId;
            this.FacilityId = facilityId;
            this.AccessPeriod = accessPeriod;
        }

        public void ChangeAccessPeriod(AccessPeriod accessPeriod)
        {
            this.AccessPeriod = accessPeriod;
        }

        public bool ValidateAccessValidity()
        {
            return AccessPeriod.IsWithinAccessPeriod(DateOnly.FromDateTime(DateTime.Today));
        }
    }
}
using System;
using FacilityAccessService.Business.Common;
using FacilityAccessService.Business.Common.ValueObjects;
using FacilityAccessService.Business.User.Models;

namespace FacilityAccessService.Business.Access.Models
{
    public class UserClientObject : BaseEntity
    {
        public Guid UserClientId { get; private set; }
        public Guid ObjectId { get; private set; }
        public AccessPeriod AccessPeriod { get; private set; }


        public UserClientObject(
            Guid userClientId,
            Guid objectId,
            AccessPeriod accessPeriod)
        {
            this.UserClientId = userClientId;
            this.ObjectId = objectId;
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
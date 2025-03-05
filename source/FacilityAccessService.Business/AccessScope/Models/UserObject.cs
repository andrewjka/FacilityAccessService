using System;
using FacilityAccessService.Business.AccessScope.ValueObjects;
using FacilityAccessService.Business.CommonScope;

namespace FacilityAccessService.Business.AccessScope.Models
{
    public class UserObject : BaseEntity
    {
        public Guid UserId { get; private set; }
        public Guid ObjectId { get; private set; }
        public AccessPeriod AccessPeriod { get; private set; }


        public UserObject(
            Guid userId,
            Guid objectId,
            AccessPeriod accessPeriod
        ) : base()
        {
            this.UserId = userId;
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
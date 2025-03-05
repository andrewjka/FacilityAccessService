using System;
using FacilityAccessService.Business.Common;
using FacilityAccessService.Business.Common.ValueObjects;
using FacilityAccessService.Business.User.Models;

namespace FacilityAccessService.Business.Access.Models
{
    public class UserObject : BaseEntity, IUserPassModel
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
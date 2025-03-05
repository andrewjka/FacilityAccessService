using System;
using FacilityAccessService.Business.Access.Actions;
using FacilityAccessService.Business.Common;
using FacilityAccessService.Business.Common.ValueObjects;

namespace FacilityAccessService.Business.Access.Models
{
    public class UserClientCategory : BaseEntity
    {
        public Guid UserClientId { get; private set; }
        public Guid CategoryId { get; private set; }
        public AccessPeriod AccessPeriod { get; private set; }


        public UserClientCategory(
            Guid userClientId,
            Guid categoryId,
            AccessPeriod accessPeriod
        ) : base()
        {
            this.UserClientId = userClientId;
            this.CategoryId = categoryId;
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
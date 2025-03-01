using System;
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
            AccessPeriod accessPeriod)
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
            return AccessPeriod.IsValidAt(DateOnly.FromDateTime(DateTime.Today));
        }
    }
}
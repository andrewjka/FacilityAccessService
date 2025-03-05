using System;
using FacilityAccessService.Business.Access.Actions;
using FacilityAccessService.Business.Common;
using FacilityAccessService.Business.Common.ValueObjects;

namespace FacilityAccessService.Business.Access.Models
{
    public class UserCategory : BaseEntity
    {
        public Guid UserId { get; private set; }
        public Guid CategoryId { get; private set; }
        public AccessPeriod AccessPeriod { get; private set; }


        public UserCategory(
            Guid userId,
            Guid categoryId,
            AccessPeriod accessPeriod
        ) : base()
        {
            this.UserId = userId;
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
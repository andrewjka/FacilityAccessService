using System;
using FacilityAccessService.Business.AccessScope.ValueObjects;
using FacilityAccessService.Business.CommonScope.Models;

namespace FacilityAccessService.Business.AccessScope.Models
{
    public class UserCategory
    {
        public string UserId { get; private set; }
        public Guid CategoryId { get; private set; }
        public AccessPeriod AccessPeriod { get; private set; }


        public UserCategory(
            string userId,
            Guid categoryId,
            AccessPeriod accessPeriod
        )
        {
            this.UserId = userId;
            this.CategoryId = categoryId;
            this.AccessPeriod = accessPeriod;
        }

        public void ChangeAccessPeriod(AccessPeriod accessPeriod)
        {
            this.AccessPeriod = accessPeriod;
        }
        
        /// <summary>
        /// Checks whether the access permit has expired.
        /// </summary>
        public bool IsAccessValid()
        {
            return AccessPeriod.IsWithinAccessPeriod(DateOnly.FromDateTime(DateTime.Today));
        }
    }
}
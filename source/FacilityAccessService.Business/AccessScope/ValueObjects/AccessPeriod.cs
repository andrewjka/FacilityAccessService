using System;

namespace FacilityAccessService.Business.AccessScope.ValueObjects
{
    /// <summary>
    /// Describes the period during which the access is valid.
    /// </summary>
    public record AccessPeriod
    {
        public DateOnly StartDate { get; init; }
        public DateOnly EndDate { get; init; }

        public AccessPeriod(DateOnly startDate, DateOnly endDate)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
        }
        
        /// <summary>
        /// Checks if the date is within the access period.
        /// </summary>
        public bool IsWithinAccessPeriod(DateOnly currentDate)
        {
            return EndDate >= currentDate && currentDate >= StartDate;
        }
    }
}
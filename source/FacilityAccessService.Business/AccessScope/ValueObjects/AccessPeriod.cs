using System;

namespace FacilityAccessService.Business.AccessScope.ValueObjects
{
    public record AccessPeriod
    {
        public DateOnly StartDate { get; init; }
        public DateOnly EndDate { get; init; }

        public AccessPeriod(DateOnly startDate, DateOnly endDate)
        {
            this.StartDate = startDate;
            this.EndDate = EndDate;
        }

        public bool IsWithinAccessPeriod(DateOnly currentDate)
        {
            return EndDate >= currentDate && currentDate >= StartDate;
        }
    }
}
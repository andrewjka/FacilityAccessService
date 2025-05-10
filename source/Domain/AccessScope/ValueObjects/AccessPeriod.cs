#region

using System;

#endregion

namespace Domain.AccessScope.ValueObjects;

/// <summary>
///     Describes the period during which the access is valid.
/// </summary>
public record AccessPeriod
{
    public AccessPeriod(DateOnly startDate, DateOnly endDate)
    {
        StartDate = startDate;
        EndDate = endDate;
    }

    public DateOnly StartDate { get; init; }
    public DateOnly EndDate { get; init; }

    /// <summary>
    ///     Checks if the date is within the access period.
    /// </summary>
    public bool IsWithinAccessPeriod(DateOnly currentDate)
    {
        return currentDate >= StartDate && currentDate <= EndDate;
    }
}
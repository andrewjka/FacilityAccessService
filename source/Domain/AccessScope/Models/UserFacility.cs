#region

using System;
using Domain.AccessScope.ValueObjects;

#endregion

namespace Domain.AccessScope.Models;

public class UserFacility
{
    public UserFacility(
        string userId,
        Guid facilityId,
        AccessPeriod accessPeriod
    )
    {
        UserId = userId;
        FacilityId = facilityId;
        AccessPeriod = accessPeriod;
    }

    public string UserId { get; private set; }
    public Guid FacilityId { get; private set; }
    public AccessPeriod AccessPeriod { get; private set; }

    public void ChangeAccessPeriod(AccessPeriod accessPeriod)
    {
        AccessPeriod = accessPeriod;
    }

    /// <summary>
    ///     Checks whether the access permit has expired.
    /// </summary>
    public bool IsAccessValid()
    {
        return AccessPeriod.IsWithinAccessPeriod(DateOnly.FromDateTime(DateTime.Today));
    }
}
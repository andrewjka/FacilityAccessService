#region

using System;
using Domain.AccessScope.ValueObjects;

#endregion

namespace Domain.AccessScope.Models;

public class UserCategory
{
    public UserCategory(
        string userId,
        Guid categoryId,
        AccessPeriod accessPeriod
    )
    {
        UserId = userId;
        CategoryId = categoryId;
        AccessPeriod = accessPeriod;
    }

    public string UserId { get; private set; }
    public Guid CategoryId { get; private set; }
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
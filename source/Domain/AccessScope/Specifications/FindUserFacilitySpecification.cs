#region

using System;
using Domain.AccessScope.Models;
using Domain.CommonScope.Specification;

#endregion

namespace Domain.AccessScope.Specifications;

public class FindUserFacilitySpecification : Specification<UserFacility>
{
    /// <summary>
    ///     Finds the specific access of a user to a specific category.
    ///     <param name="isOnlyActive">If true, returns only non-expired records</param>
    /// </summary>
    public FindUserFacilitySpecification(string userId, Guid facilityId, bool isOnlyActive = false)
    {
        if (isOnlyActive)
        {
            var currentDate = DateOnly.FromDateTime(DateTime.Today);

            ApplyExpression(userFacility =>
                userFacility.UserId == userId &&
                userFacility.FacilityId == facilityId &&
                currentDate >= userFacility.AccessPeriod.StartDate &&
                currentDate <= userFacility.AccessPeriod.EndDate
            );
        }
        else
        {
            ApplyExpression(userFacility =>
                userFacility.UserId == userId && userFacility.FacilityId == facilityId
            );
        }
    }
}
#region

using System;
using FacilityAccessService.Business.AccessScope.Models;
using FacilityAccessService.Business.CommonScope.Specification;

#endregion

namespace FacilityAccessService.Business.AccessScope.Specifications
{
    public class FindUserFacilitySpecification : Specification<UserFacility>
    {
        /// <summary>
        /// Finds the specific access of a user to a specific category.
        /// <param name="isOnlyActive">If true, returns only non-expired records</param>
        /// </summary>
        public FindUserFacilitySpecification(string userId, Guid facilityId, bool isOnlyActive = false)
        {
            if (isOnlyActive)
            {
                DateOnly currentDate = DateOnly.FromDateTime(DateTime.Today);

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
}
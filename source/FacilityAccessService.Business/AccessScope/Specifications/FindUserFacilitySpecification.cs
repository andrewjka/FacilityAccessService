using System;
using FacilityAccessService.Business.AccessScope.Models;
using FacilityAccessService.Business.CommonScope.Specification;

namespace FacilityAccessService.Business.AccessScope.Specifications
{
    public class FindUserFacilitySpecification : Specification<UserFacility>
    {
        public FindUserFacilitySpecification(Guid userId, Guid facilityId)
        {
            ApplyExpression(userFacility =>
                userFacility.UserId == userId && userFacility.FacilityId == facilityId
            );
        }
    }
}
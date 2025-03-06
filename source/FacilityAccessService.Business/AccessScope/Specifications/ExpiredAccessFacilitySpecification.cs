using System;
using FacilityAccessService.Business.AccessScope.Models;
using FacilityAccessService.Business.CommonScope.Specification;

namespace FacilityAccessService.Business.AccessScope.Specifications
{
    public class ExpiredAccessFacilitySpecification : Specification<UserFacility>
    {
        public ExpiredAccessFacilitySpecification(int take)
        {
            ApplyExpression(userClientObject =>
                userClientObject.AccessPeriod.EndDate < DateOnly.FromDateTime(DateTime.Today)
            );

            ApplyPaging(0, take);
        }
    }
}
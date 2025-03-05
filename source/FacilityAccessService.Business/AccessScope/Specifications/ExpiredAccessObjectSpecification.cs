using System;
using FacilityAccessService.Business.AccessScope.Models;
using FacilityAccessService.Business.CommonScope.Specification;

namespace FacilityAccessService.Business.AccessScope.Specifications
{
    public class ExpiredAccessObjectSpecification : Specification<UserObject>
    {
        public ExpiredAccessObjectSpecification(int skip, int take)
        {
            ApplyExpression(userClientObject =>
                userClientObject.AccessPeriod.EndDate < DateOnly.FromDateTime(DateTime.Today)
            );
            
            ApplyPaging(skip, take);
        }
    }
}
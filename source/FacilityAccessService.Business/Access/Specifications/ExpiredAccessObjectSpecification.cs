using System;
using FacilityAccessService.Business.Access.Models;
using FacilityAccessService.Business.Common.Specification;

namespace FacilityAccessService.Business.Access.Specifications
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
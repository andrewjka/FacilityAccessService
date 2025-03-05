using System;
using FacilityAccessService.Business.Access.Models;
using FacilityAccessService.Business.Common.Specification;

namespace FacilityAccessService.Business.Access.Specifications
{
    public class ExpiredAccessCategorySpecification : Specification<UserClientCategory>
    {
        public ExpiredAccessCategorySpecification(int skip, int take)
        {
            ApplyExpression(userClientCategory =>
                userClientCategory.AccessPeriod.EndDate < DateOnly.FromDateTime(DateTime.Today)
            );
            
            ApplyPaging(skip, take);
        }
    }
}
using System;
using FacilityAccessService.Business.AccessScope.Models;
using FacilityAccessService.Business.CommonScope.Specification;

namespace FacilityAccessService.Business.AccessScope.Specifications
{
    public class ExpiredAccessCategorySpecification : Specification<UserCategory>
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
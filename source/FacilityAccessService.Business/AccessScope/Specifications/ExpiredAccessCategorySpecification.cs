#region

using System;
using FacilityAccessService.Business.AccessScope.Models;
using FacilityAccessService.Business.CommonScope.Specification;

#endregion

namespace FacilityAccessService.Business.AccessScope.Specifications
{
    public class ExpiredAccessCategorySpecification : Specification<UserCategory>
    {
        public ExpiredAccessCategorySpecification(int take)
        {
            ApplyExpression(userClientCategory =>
                userClientCategory.AccessPeriod.EndDate < DateOnly.FromDateTime(DateTime.Today)
            );
            
            ApplyPaging(0, take);
        }
    }
}
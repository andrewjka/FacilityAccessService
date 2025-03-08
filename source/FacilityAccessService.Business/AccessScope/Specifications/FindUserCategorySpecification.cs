using System;
using FacilityAccessService.Business.AccessScope.Models;
using FacilityAccessService.Business.CommonScope.Specification;

namespace FacilityAccessService.Business.AccessScope.Specifications
{
    public class FindUserCategorySpecification : Specification<UserCategory>
    {
        public FindUserCategorySpecification(string userId, Guid categoryId)
        {
            ApplyExpression(userCategory =>
                userCategory.UserId == userId && userCategory.CategoryId == categoryId
            );
        }
    }
}
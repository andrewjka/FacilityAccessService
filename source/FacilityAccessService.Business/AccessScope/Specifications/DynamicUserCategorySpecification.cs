using FacilityAccessService.Business.AccessScope.Models;
using FacilityAccessService.Business.CommonScope.Specification;

namespace FacilityAccessService.Business.AccessScope.Specifications
{
    public class DynamicUserCategorySpecification : Specification<UserCategory>
    {
        public DynamicUserCategorySpecification(string userId, int? take = null, int? offset = null)
        {
            ApplyExpression(userCategory => userCategory.UserId == userId);

            ApplyPaging(offset: offset ?? 0, take: take ?? 0);
        }
    }
}
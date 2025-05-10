using Domain.AccessScope.Models;
using Domain.CommonScope.Specification;

namespace Domain.AccessScope.Specifications;

public class DynamicUserCategorySpecification : Specification<UserCategory>
{
    public DynamicUserCategorySpecification(string userId, int? take = null, int? offset = null)
    {
        ApplyExpression(userCategory => userCategory.UserId == userId);

        ApplyPaging(offset ?? 0, take ?? 0);
    }
}
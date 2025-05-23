using Domain.CommonScope.Specification;
using Domain.UserScope.Models;

namespace Domain.UserScope.Specifications;

public class DynamicUserSpecification : Specification<User>
{
    public DynamicUserSpecification(int? take = null, int? offset = null, string searchId = null)
    {
        ApplyPaging(offset ?? 0, take ?? 0);

        if (!string.IsNullOrEmpty(searchId)) ApplyExpression(user => user.Email.Contains(searchId));
    }
}
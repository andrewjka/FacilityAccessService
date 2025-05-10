using Domain.AccessScope.Models;
using Domain.CommonScope.Specification;

namespace Domain.AccessScope.Specifications;

public class DynamicUserFacilitySpecification : Specification<UserFacility>
{
    public DynamicUserFacilitySpecification(string userId, int? take = null, int? offset = null)
    {
        ApplyExpression(userFacility => userFacility.UserId == userId);

        ApplyPaging(offset ?? 0, take ?? 0);
    }
}
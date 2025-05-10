using Domain.CommonScope.Specification;
using Domain.FacilityScope.Models;

namespace Domain.FacilityScope.Specifications;

public class DynamicFacilitySpecification : Specification<Facility>
{
    public DynamicFacilitySpecification(int? take = null, int? offset = null, string searchName = null)
    {
        ApplyPaging(offset ?? 0, take ?? 0);

        if (!string.IsNullOrEmpty(searchName)) ApplyExpression(facility => facility.Name.Contains(searchName));
    }
}
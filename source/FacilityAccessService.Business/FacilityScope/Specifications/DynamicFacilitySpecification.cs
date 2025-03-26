using FacilityAccessService.Business.CommonScope.Specification;
using FacilityAccessService.Business.FacilityScope.Models;

namespace FacilityAccessService.Business.FacilityScope.Specifications
{
    public class DynamicFacilitySpecification : Specification<Facility>
    {
        public DynamicFacilitySpecification(int? take = null, int? offset = null, string searchName = null)
        {
            ApplyPaging(offset: offset ?? 0, take: take ?? 0);

            if (!string.IsNullOrEmpty(searchName))
            {
                ApplyExpression(facility => facility.Name.Contains(searchName));
            }
        }
    }
}
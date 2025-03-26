using FacilityAccessService.Business.AccessScope.Models;
using FacilityAccessService.Business.CommonScope.Specification;

namespace FacilityAccessService.Business.AccessScope.Specifications
{
    public class DynamicUserFacilitySpecification : Specification<UserFacility>
    {
        public DynamicUserFacilitySpecification(string userId, int? take = null, int? offset = null)
        {
            ApplyExpression(userFacility => userFacility.UserId == userId);

            ApplyPaging(offset: offset ?? 0, take: take ?? 0);
        }
    }
}
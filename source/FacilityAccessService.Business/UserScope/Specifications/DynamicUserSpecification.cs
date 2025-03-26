using System.Linq;
using FacilityAccessService.Business.CommonScope.Specification;
using FacilityAccessService.Business.UserScope.Models;

namespace FacilityAccessService.Business.UserScope.Specifications
{
    public class DynamicUserSpecification : Specification<User>
    {
        public DynamicUserSpecification(int? take = null, int? offset = null, string searchId = null)
        {
            ApplyPaging(offset: offset ?? 0, take: take ?? 0);

            if (!string.IsNullOrEmpty(searchId))
            {
                ApplyExpression(user => user.Id.Contains(searchId));
            }
        }
    }
}
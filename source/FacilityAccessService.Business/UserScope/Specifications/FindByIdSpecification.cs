#region

using FacilityAccessService.Business.CommonScope.Specification;
using FacilityAccessService.Business.UserScope.Models;

#endregion

namespace FacilityAccessService.Business.UserScope.Specifications
{
    public class FindByIdSpecification : Specification<User>
    {
        public FindByIdSpecification(string id)
        {
            ApplyExpression(entity => entity.Id == id);
        }
    }
}
using FacilityAccessService.Business.CommonScope.Specification;
using FacilityAccessService.Business.TerminalScope.Models;

namespace FacilityAccessService.Business.TerminalScope.Specifications
{
    public class DynamicTerminalSpecification : Specification<Terminal>
    {
        public DynamicTerminalSpecification(int? take = null, int? offset = null, string searchName = null)
        {
            ApplyPaging(offset: offset ?? 0, take: take ?? 0);

            if (!string.IsNullOrEmpty(searchName))
            {
                ApplyExpression(user => user.Name.Contains(searchName));
            }
        }
    }
}
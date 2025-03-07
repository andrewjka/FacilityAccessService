using FacilityAccessService.Business.CommonScope.Specification;
using FacilityAccessService.Business.TerminalScope.Models;
using FacilityAccessService.Business.TerminalScope.ValueObjects;

namespace FacilityAccessService.Business.TerminalScope.Specifications
{
    public class FindByTerminalTokenSpecification : Specification<Terminal>
    {
        public FindByTerminalTokenSpecification(TerminalToken token)
        {
            ApplyExpression(terminal => terminal.Token == token);
        }
    }
}
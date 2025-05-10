using Domain.CommonScope.Specification;
using Domain.TerminalScope.Models;

namespace Domain.TerminalScope.Specifications;

public class DynamicTerminalSpecification : Specification<Terminal>
{
    public DynamicTerminalSpecification(int? take = null, int? offset = null, string searchName = null)
    {
        ApplyPaging(offset ?? 0, take ?? 0);

        if (!string.IsNullOrEmpty(searchName)) ApplyExpression(user => user.Name.Contains(searchName));
    }
}
#region

using Domain.CommonScope.Specification;
using Domain.TerminalScope.Models;
using Domain.TerminalScope.ValueObjects;

#endregion

namespace Domain.TerminalScope.Specifications;

public class FindByTerminalTokenSpecification : Specification<Terminal>
{
    public FindByTerminalTokenSpecification(TerminalToken token)
    {
        ApplyExpression(terminal => terminal.Token == token);
    }
}
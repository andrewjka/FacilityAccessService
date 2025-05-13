using Domain.CommonScope.Specification;
using Domain.CommonScope.ValueObjects;
using Domain.TerminalScope.Models;

namespace Domain.TerminalScope.Specifications;

public class FindByTerminalTokenSpecification : Specification<Terminal>
{
    public FindByTerminalTokenSpecification(Token512Bit token)
    {
        ApplyExpression(terminal => terminal.Token == token);
    }
}
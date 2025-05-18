using Domain.AuthScope.Models;
using Domain.CommonScope.Specification;
using Domain.CommonScope.ValueObjects;

namespace Domain.AuthScope.Specifications;

public class FindByTokenSpecification : Specification<RefreshToken>
{
    public FindByTokenSpecification(Token512Bit token)
    {
        ApplyExpression(entity => entity.Token == token);
    }
}
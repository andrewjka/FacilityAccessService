using Domain.CommonScope.Specification;
using Domain.UserScope.Models;

namespace Domain.UserScope.Specifications;

public class FindByEmailSpecification : Specification<User>
{
    public FindByEmailSpecification(string email)
    {
        ApplyExpression(entity => entity.Email == email);
    }
}
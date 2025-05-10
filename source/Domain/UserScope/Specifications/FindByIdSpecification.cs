#region

using Domain.CommonScope.Specification;
using Domain.UserScope.Models;

#endregion

namespace Domain.UserScope.Specifications;

public class FindByIdSpecification : Specification<User>
{
    public FindByIdSpecification(string id)
    {
        ApplyExpression(entity => entity.Id == id);
    }
}
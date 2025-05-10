#region

using System;
using Domain.CommonScope.Models;
using Domain.CommonScope.Specification;

#endregion

namespace Domain.CommonScope.Specifications.Generic;

public class FindByGUIDSpecification<TEntity> : Specification<TEntity> where TEntity : BaseEntity
{
    public FindByGUIDSpecification(Guid guid)
    {
        ApplyExpression(entity => entity.Id == guid);
    }
}
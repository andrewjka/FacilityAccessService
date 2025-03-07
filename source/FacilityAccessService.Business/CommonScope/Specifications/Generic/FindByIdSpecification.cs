using System;
using FacilityAccessService.Business.CommonScope.Specification;

namespace FacilityAccessService.Business.CommonScope.Specifications.Generic
{
    public class FindByIdSpecification<TEntity> : Specification<TEntity> where TEntity : BaseEntity
    {
        public FindByIdSpecification(Guid guid)
        {
            ApplyExpression(entity => entity.Id == guid);
        }
    }
}
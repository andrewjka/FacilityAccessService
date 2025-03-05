using System;
using FacilityAccessService.Business.CommonScope.Specification;

namespace FacilityAccessService.Business.CommonScope.Specifications.Generic
{
    public class FirstByIdSpecification<TEntity> : Specification<TEntity> where TEntity : BaseEntity
    {
        public FirstByIdSpecification(Guid guid)
        {
            ApplyExpression(entity => entity.Id == guid);
        }
    }
}
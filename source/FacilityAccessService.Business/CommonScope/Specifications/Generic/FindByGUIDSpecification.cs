using System;
using FacilityAccessService.Business.CommonScope.Models;
using FacilityAccessService.Business.CommonScope.Specification;

namespace FacilityAccessService.Business.CommonScope.Specifications.Generic
{
    public class FindByGUIDSpecification<TEntity> : Specification<TEntity> where TEntity : BaseEntity
    {
        public FindByGUIDSpecification(Guid guid)
        {
            ApplyExpression(entity => entity.Id == guid);
        }
    }
}
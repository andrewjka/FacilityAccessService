using System;
using System.Collections.Generic;
using FacilityAccessService.Business.CommonScope.Specification;
using FacilityAccessService.Business.FacilityScope.Models;

namespace FacilityAccessService.Business.FacilityScope.Specifications
{
    public class FindAllFacilitiesByIds : Specification<Facility>
    {
        public FindAllFacilitiesByIds(HashSet<Guid> facilitiesId)
        {
            ApplyExpression(entity => facilitiesId.Contains(entity.Id));
        }
    }
}
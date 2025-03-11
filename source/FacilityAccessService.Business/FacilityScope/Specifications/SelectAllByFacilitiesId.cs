using System;
using System.Collections.Generic;
using FacilityAccessService.Business.CommonScope.Specification;
using FacilityAccessService.Business.FacilityScope.Models;

namespace FacilityAccessService.Business.FacilityScope.Specifications
{
    public class SelectAllByFacilitiesId : Specification<Facility>
    {
        public SelectAllByFacilitiesId(HashSet<Guid> facilitiesId)
        {
            ApplyExpression(entity => facilitiesId.Contains(entity.Id));
        }
    }
}
#region

using System;
using System.Collections.Generic;
using Domain.CommonScope.Specification;
using Domain.FacilityScope.Models;

#endregion

namespace Domain.FacilityScope.Specifications;

public class FindAllFacilitiesByIds : Specification<Facility>
{
    public FindAllFacilitiesByIds(HashSet<Guid> facilitiesId)
    {
        ApplyExpression(entity => facilitiesId.Contains(entity.Id));
    }
}
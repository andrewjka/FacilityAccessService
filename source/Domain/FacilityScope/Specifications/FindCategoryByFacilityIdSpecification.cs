#region

using System;
using System.Collections.Generic;
using System.Linq;
using Domain.CommonScope.Specification;
using Domain.FacilityScope.Models;

#endregion

namespace Domain.FacilityScope.Specifications;

public class FindCategoryByFacilityIdSpecification : Specification<Category>
{
    /// <summary>
    ///     Find among the given categories those that contain a FacilityId.
    /// </summary>
    public FindCategoryByFacilityIdSpecification(HashSet<Guid> categoriesId, Guid facilityId)
    {
        ApplyExpression(category => categoriesId.Contains(category.Id) &&
                                    category.Facilities.Any(facility => facility.Id == facilityId)
        );
    }
}
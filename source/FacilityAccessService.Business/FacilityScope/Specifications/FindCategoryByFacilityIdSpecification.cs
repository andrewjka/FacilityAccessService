#region

using System;
using System.Collections.Generic;
using System.Linq;
using FacilityAccessService.Business.CommonScope.Specification;
using FacilityAccessService.Business.FacilityScope.Models;

#endregion

namespace FacilityAccessService.Business.FacilityScope.Specifications
{
    public class FindCategoryByFacilityIdSpecification : Specification<Category>
    {
        /// <summary>
        /// Find among the given categories those that contain a FacilityId.
        /// </summary>
        public FindCategoryByFacilityIdSpecification(HashSet<Guid> categoriesId, Guid facilityId)
        {
            ApplyExpression(category => categoriesId.Contains(category.Id) &&
                                        category.Facilities.Any(facility => facility.Id == facilityId)
            );
        }
    }
}
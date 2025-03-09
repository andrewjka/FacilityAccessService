using System.Collections.Generic;
using FacilityAccessService.Business.FacilityScope.Models;

namespace FacilityAccessService.Business.FacilityScope.Actions
{
    /// <summary>
    /// The action model for creating a category. 
    /// </summary>
    public record CreateCategoryModel(
        string Name,
        HashSet<Facility> Facilities
    );
}
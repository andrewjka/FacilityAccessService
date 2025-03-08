using System.Collections.Generic;
using FacilityAccessService.Business.FacilityScope.Models;

namespace FacilityAccessService.Business.FacilityScope.Actions
{
    public record CreateCategoryModel(
        string Name,
        HashSet<Facility> Facilities
    );
}
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FacilityAccessService.Business.FacilityScope.Actions
{
    public record CreateCategoryModel(
        string Name,
        HashSet<Models.Facility> Facilities
    );
}
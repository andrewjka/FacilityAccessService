using System.Collections.ObjectModel;

namespace FacilityAccessService.Business.FacilityScope.Actions
{
    public record CreateCategoryModel(
        string Name,
        ReadOnlyCollection<Models.Facility> Objects
    );
}
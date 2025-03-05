using System.Collections.ObjectModel;

namespace FacilityAccessService.Business.ObjectScope.Actions
{
    public record CreateCategoryModel(
        string Name,
        ReadOnlyCollection<Models.Object> Objects
    );
}
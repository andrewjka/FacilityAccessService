using System.Collections.ObjectModel;

namespace FacilityAccessService.Business.Object.Actions
{
    public record CreateCategoryModel(
        string Name,
        ReadOnlyCollection<Models.Object> Objects
    );
}
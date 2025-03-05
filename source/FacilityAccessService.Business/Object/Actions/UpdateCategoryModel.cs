using System;
using System.Collections.ObjectModel;

namespace FacilityAccessService.Business.Object.Actions
{
    public record UpdateCategoryModel(
        Guid CategoryId,
        string Name,
        ReadOnlyCollection<Models.Object> Objects
    );
}
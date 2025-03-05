using System;
using System.Collections.ObjectModel;

namespace FacilityAccessService.Business.ObjectScope.Actions
{
    public record UpdateCategoryModel(
        Guid CategoryId,
        string Name,
        ReadOnlyCollection<Object> Objects
    );
}
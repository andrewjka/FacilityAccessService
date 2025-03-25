#region

using System;
using System.Collections.Generic;

#endregion

namespace FacilityAccessService.Business.FacilityScope.Actions
{
    /// <summary>
    /// The action model for updating the Category. 
    /// </summary>
    public record UpdateCategoryModel(
        Guid CategoryId,
        string Name,
        HashSet<Guid> FacilitiesId
    );
}
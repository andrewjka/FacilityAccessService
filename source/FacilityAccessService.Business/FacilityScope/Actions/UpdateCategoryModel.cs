using System;
using System.Collections.Generic;
using FacilityAccessService.Business.FacilityScope.Models;

namespace FacilityAccessService.Business.FacilityScope.Actions
{
    /// <summary>
    /// The action model for updating the Category. 
    /// </summary>
    public record UpdateCategoryModel(
        Guid CategoryId,
        string Name,
        HashSet<Facility> Facilities
    );
}
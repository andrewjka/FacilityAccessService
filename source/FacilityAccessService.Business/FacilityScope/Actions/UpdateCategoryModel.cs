using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FacilityAccessService.Business.FacilityScope.Models;

namespace FacilityAccessService.Business.FacilityScope.Actions
{
    public record UpdateCategoryModel(
        Guid CategoryId,
        string Name,
        HashSet<Facility> Facilities
    );
}
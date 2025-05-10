#region

using System;
using System.Collections.Generic;

#endregion

namespace Domain.FacilityScope.Actions;

/// <summary>
///     The action model for creating a category.
/// </summary>
public record CreateCategoryModel(
    string Name,
    HashSet<Guid> FacilitiesId
);
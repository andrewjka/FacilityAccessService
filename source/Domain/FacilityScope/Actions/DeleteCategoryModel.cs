#region

using System;

#endregion

namespace Domain.FacilityScope.Actions;

/// <summary>
///     The action model for deleting the Category.
/// </summary>
public record DeleteCategoryModel(Guid CategoryId);
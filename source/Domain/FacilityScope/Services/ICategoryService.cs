#region

using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Domain.CommonScope.Specification;
using Domain.FacilityScope.Actions;
using Domain.FacilityScope.Models;

#endregion

namespace Domain.FacilityScope.Services;

/// <summary>
///     Describes the service for the main cases with the Category entity.
/// </summary>
public interface ICategoryService
{
    /// <summary>
    ///     Creates a new Category.
    /// </summary>
    public Task<Category> CreateCategoryAsync(CreateCategoryModel createCategoryModel);

    /// <summary>
    ///     Get the Category by specification.
    /// </summary>
    public Task<Category> GetCategoryAsync(Specification<Category> specification);

    /// <summary>
    ///     Get all Categories by specification.
    /// </summary>
    public Task<ReadOnlyCollection<Category>> GetCategoriesAsync(Specification<Category> specification);

    /// <summary>
    ///     Updates the Category.
    /// </summary>
    public Task<Category> UpdateCategoryAsync(UpdateCategoryModel updateCategoryModel);

    /// <summary>
    ///     Deletes the Category.
    /// </summary>
    public Task DeleteCategoryAsync(DeleteCategoryModel deleteCategoryModel);
}
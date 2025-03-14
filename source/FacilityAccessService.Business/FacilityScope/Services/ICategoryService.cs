using System.Threading.Tasks;
using FacilityAccessService.Business.FacilityScope.Actions;
using FacilityAccessService.Business.FacilityScope.Models;

namespace FacilityAccessService.Business.FacilityScope.Services
{
    /// <summary>
    /// Describes the service for the main cases with the Category entity.
    /// </summary>
    public interface ICategoryService
    {
        /// <summary>
        /// Creates a new Category.
        /// </summary>
        public Task<Category> CreateCategoryAsync(CreateCategoryModel createCategoryModel);

        /// <summary>
        /// Updates the Category.
        /// </summary>
        public Task<Category> UpdateCategoryAsync(UpdateCategoryModel updateCategoryModel);

        /// <summary>
        /// Deletes the Category.
        /// </summary>
        public Task DeleteCategoryAsync(DeleteCategoryModel deleteCategoryModel);
    }
}
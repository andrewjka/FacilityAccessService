using System.Threading.Tasks;
using FacilityAccessService.Business.ObjectScope.Actions;
using FacilityAccessService.Business.ObjectScope.Models;

namespace FacilityAccessService.Business.ObjectScope.Services
{
    /// <summary>
    /// Describes the service for the main cases with the Category entity.
    /// </summary>
    public interface ICategoryService
    {
        public Task<Category> CreateCategoryAsync(CreateCategoryModel createCategoryModel);

        public Task<Category> UpdateCategoryAsync(UpdateCategoryModel updateCategoryModel);

        public Task DeleteCategoryAsync(DeleteCategoryModel deleteCategoryModel);
    }
}
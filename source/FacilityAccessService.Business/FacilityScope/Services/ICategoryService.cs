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
        public Task<Category> CreateCategoryAsync(CreateCategoryModel createCategoryModel);

        public Task<Category> UpdateCategoryAsync(UpdateCategoryModel updateCategoryModel);

        public Task DeleteCategoryAsync(DeleteCategoryModel deleteCategoryModel);
    }
}
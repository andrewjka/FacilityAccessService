using System.Threading.Tasks;
using FacilityAccessService.Business.Object.Actions;

namespace FacilityAccessService.Business.Object.Services
{
    /// <summary>
    /// Describes the service for the main cases with the Category entity.
    /// </summary>
    public interface ICategoryService
    {
        public Task CreateCategoryAsync(CreateCategoryModel createCategoryModel);

        public Task UpdateCategoryAsync(UpdateCategoryModel updateCategoryModel);

        public Task DeleteCategoryAsync(DeleteCategoryModel deleteCategoryModel);
    }
}
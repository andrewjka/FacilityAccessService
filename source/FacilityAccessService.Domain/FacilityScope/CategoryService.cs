using System;
using System.Threading.Tasks;
using FacilityAccessService.Business.CommonScope.Specifications.Generic;
using FacilityAccessService.Business.FacilityScope.Actions;
using FacilityAccessService.Business.FacilityScope.Exceptions;
using FacilityAccessService.Business.FacilityScope.Models;
using FacilityAccessService.Business.FacilityScope.Repositories;
using FacilityAccessService.Business.FacilityScope.Services;
using FluentValidation;

namespace FacilityAccessService.Domain.FacilityScope
{
    public class CategoryService : ICategoryService
    {
        private IValidator<CreateCategoryModel> _createCategoryVL;
        private IValidator<UpdateCategoryModel> _updateCategoryVL;
        private IValidator<DeleteCategoryModel> _deleteCategoryVL;
        private IValidator<Category> _categoryVL;

        private ICategoryRepository _categoryRepository;


        public CategoryService(
            IValidator<CreateCategoryModel> createCategoryVL,
            IValidator<UpdateCategoryModel> updateCategoryVL,
            IValidator<DeleteCategoryModel> deleteCategoryVL,
            IValidator<Category> categoryVL,
            ICategoryRepository categoryRepository
        )
        {
            if (createCategoryVL is null) throw new ArgumentNullException(nameof(createCategoryVL));
            if (updateCategoryVL is null) throw new ArgumentNullException(nameof(updateCategoryVL));
            if (deleteCategoryVL is null) throw new ArgumentNullException(nameof(deleteCategoryVL));
            if (categoryVL is null) throw new ArgumentNullException(nameof(categoryVL));
            
            if (categoryRepository is null) throw new ArgumentNullException(nameof(categoryRepository));

            this._createCategoryVL = createCategoryVL;
            this._updateCategoryVL = updateCategoryVL;
            this._deleteCategoryVL = deleteCategoryVL;
            this._categoryVL = categoryVL;
            this._categoryRepository = categoryRepository;
        }


        public async Task<Category> CreateCategoryAsync(CreateCategoryModel createCategoryModel)
        {
            _createCategoryVL.ValidateAndThrow(createCategoryModel);


            Category category = new Category(
                name: createCategoryModel.Name,
                facilities: createCategoryModel.Facilities
            );

            _categoryVL.ValidateAndThrow(category);


            await _categoryRepository.CreateAsync(category);

            return category;
        }

        public async Task<Category> UpdateCategoryAsync(UpdateCategoryModel updateCategoryModel)
        {
            _updateCategoryVL.ValidateAndThrow(updateCategoryModel);


            FindByGUIDSpecification<Category> findByGuidSpec = new FindByGUIDSpecification<Category>(
                guid: updateCategoryModel.CategoryId
            );

            Category category = await _categoryRepository.FirstByAsync(findByGuidSpec);
            if (category is null)
            {
                throw new CategoryNotFoundException("The category with the specified id does not exist.");
            }

            if (updateCategoryModel.Name is not null)
            {
                category.ChangeName(updateCategoryModel.Name);
            }

            if (updateCategoryModel.Facilities is not null)
            {
                category.ChangeObjects(updateCategoryModel.Facilities);
            }

            _categoryVL.ValidateAndThrow(category);


            await _categoryRepository.UpdateAsync(category);

            return category;
        }

        public async Task DeleteCategoryAsync(DeleteCategoryModel deleteCategoryModel)
        {
            _deleteCategoryVL.ValidateAndThrow(deleteCategoryModel);


            FindByGUIDSpecification<Category> findByGuidSpec = new FindByGUIDSpecification<Category>(
                deleteCategoryModel.CategoryId
            );

            Category category = await _categoryRepository.FirstByAsync(findByGuidSpec);
            if (category is null)
            {
                throw new CategoryNotFoundException("The category with the specified id does not exist.");
            }


            await _categoryRepository.DeleteAsync(category);
        }
    }
}
using System;
using System.Threading.Tasks;
using FacilityAccessService.Business.CommonScope.PersistenceContext;
using FacilityAccessService.Business.CommonScope.Specifications.Generic;
using FacilityAccessService.Business.FacilityScope.Actions;
using FacilityAccessService.Business.FacilityScope.Exceptions;
using FacilityAccessService.Business.FacilityScope.Models;
using FacilityAccessService.Business.FacilityScope.Services;
using FluentValidation;

namespace FacilityAccessService.Domain.FacilityScope
{
    public class CategoryService : ICategoryService
    {
        private readonly IValidator<CreateCategoryModel> _createCategoryVL;
        private readonly IValidator<UpdateCategoryModel> _updateCategoryVL;
        private readonly IValidator<DeleteCategoryModel> _deleteCategoryVL;
        private readonly IValidator<Category> _categoryVL;

        private readonly IPersistenceContextFactory _persistenceContextFactory;


        public CategoryService(
            IValidator<CreateCategoryModel> createCategoryVL,
            IValidator<UpdateCategoryModel> updateCategoryVL,
            IValidator<DeleteCategoryModel> deleteCategoryVL,
            IValidator<Category> categoryVL,
            IPersistenceContextFactory persistenceContextFactory
        )
        {
            if (createCategoryVL is null) throw new ArgumentNullException(nameof(createCategoryVL));
            if (updateCategoryVL is null) throw new ArgumentNullException(nameof(updateCategoryVL));
            if (deleteCategoryVL is null) throw new ArgumentNullException(nameof(deleteCategoryVL));
            if (categoryVL is null) throw new ArgumentNullException(nameof(categoryVL));

            if (persistenceContextFactory is null) throw new ArgumentNullException(nameof(persistenceContextFactory));

            this._createCategoryVL = createCategoryVL;
            this._updateCategoryVL = updateCategoryVL;
            this._deleteCategoryVL = deleteCategoryVL;
            this._categoryVL = categoryVL;
            this._persistenceContextFactory = persistenceContextFactory;
        }


        public async Task<Category> CreateCategoryAsync(CreateCategoryModel createCategoryModel)
        {
            _createCategoryVL.ValidateAndThrow(createCategoryModel);


            Category category = new Category(
                name: createCategoryModel.Name,
                facilities: createCategoryModel.Facilities
            );

            _categoryVL.ValidateAndThrow(category);


            await using (IPersistenceContext context = await _persistenceContextFactory.CreatePersistenceContext())
            {
                await context.CategoryRepository.CreateAsync(category);

                await context.CommitAsync();
            }

            return category;
        }

        public async Task<Category> UpdateCategoryAsync(UpdateCategoryModel updateCategoryModel)
        {
            _updateCategoryVL.ValidateAndThrow(updateCategoryModel);


            FindByGUIDSpecification<Category> findByGuidSpec = new FindByGUIDSpecification<Category>(
                guid: updateCategoryModel.CategoryId
            );

            Category category;
            await using (IPersistenceContext context = await _persistenceContextFactory.CreatePersistenceContext())
            {
                category = await context.CategoryRepository.FirstByAsync(findByGuidSpec);
            }

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


            await using (IPersistenceContext context = await _persistenceContextFactory.CreatePersistenceContext())
            {
                await context.CategoryRepository.UpdateAsync(category);

                await context.CommitAsync();
            }

            return category;
        }

        public async Task DeleteCategoryAsync(DeleteCategoryModel deleteCategoryModel)
        {
            _deleteCategoryVL.ValidateAndThrow(deleteCategoryModel);


            FindByGUIDSpecification<Category> findByGuidSpec = new FindByGUIDSpecification<Category>(
                deleteCategoryModel.CategoryId
            );

            Category category;
            await using (IPersistenceContext context = await _persistenceContextFactory.CreatePersistenceContext())
            {
                category = await context.CategoryRepository.FirstByAsync(findByGuidSpec);
            }

            if (category is null)
            {
                throw new CategoryNotFoundException("The category with the specified id does not exist.");
            }


            await using (IPersistenceContext context = await _persistenceContextFactory.CreatePersistenceContext())
            {
                await context.CategoryRepository.DeleteAsync(category);

                await context.CommitAsync();
            }
        }
    }
}
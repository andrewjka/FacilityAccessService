#region

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.CommonScope.PersistenceContext;
using Domain.CommonScope.Specification;
using Domain.CommonScope.Specifications.Generic;
using Domain.FacilityScope.Actions;
using Domain.FacilityScope.Exceptions;
using Domain.FacilityScope.Models;
using Domain.FacilityScope.Services;
using Domain.FacilityScope.Specifications;
using FluentValidation;

#endregion

namespace Business.FacilityScope.Services;

public class CategoryService : ICategoryService
{
    private readonly IValidator<Category> _categoryVL;
    private readonly IValidator<CreateCategoryModel> _createCategoryVL;
    private readonly IValidator<DeleteCategoryModel> _deleteCategoryVL;

    private readonly IPersistenceContextFactory _persistenceContextFactory;
    private readonly IValidator<UpdateCategoryModel> _updateCategoryVL;


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

        _createCategoryVL = createCategoryVL;
        _updateCategoryVL = updateCategoryVL;
        _deleteCategoryVL = deleteCategoryVL;
        _categoryVL = categoryVL;
        _persistenceContextFactory = persistenceContextFactory;
    }


    public async Task<Category> CreateCategoryAsync(CreateCategoryModel createCategoryModel)
    {
        _createCategoryVL.ValidateAndThrow(createCategoryModel);


        var facilities = await GetAllFacilitiesByIds(createCategoryModel.FacilitiesId);

        var category = new Category(
            createCategoryModel.Name,
            facilities
        );

        _categoryVL.ValidateAndThrow(category);


        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            await context.CategoryRepository.CreateAsync(category);

            await context.ApplyChangesAsync();
            await context.CommitAsync();
        }

        return category;
    }

    public async Task<Category> GetCategoryAsync(Specification<Category> specification)
    {
        Category category;
        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            category = await context.CategoryRepository.FirstByAsync(specification);
        }

        return category;
    }

    public async Task<ReadOnlyCollection<Category>> GetCategoriesAsync(Specification<Category> specification)
    {
        ReadOnlyCollection<Category> categories;
        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            categories = await context.CategoryRepository.SelectByAsync(specification);
        }

        return categories;
    }

    public async Task<Category> UpdateCategoryAsync(UpdateCategoryModel updateCategoryModel)
    {
        _updateCategoryVL.ValidateAndThrow(updateCategoryModel);


        var findByGuidSpec = new FindByGUIDSpecification<Category>(
            updateCategoryModel.CategoryId
        );

        Category category;
        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            category = await context.CategoryRepository.FirstByAsync(findByGuidSpec);
        }

        if (category is null) throw new CategoryNotFoundException("The category with the specified id does not exist.");


        if (updateCategoryModel.Name is not null) category.ChangeName(updateCategoryModel.Name);

        if (updateCategoryModel.FacilitiesId is not null)
        {
            var facilities = await GetAllFacilitiesByIds(updateCategoryModel.FacilitiesId);

            category.ChangeFacilities(facilities);
        }

        _categoryVL.ValidateAndThrow(category);


        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            await context.CategoryRepository.UpdateAsync(category);

            await context.ApplyChangesAsync();
            await context.CommitAsync();
        }

        return category;
    }

    public async Task DeleteCategoryAsync(DeleteCategoryModel deleteCategoryModel)
    {
        _deleteCategoryVL.ValidateAndThrow(deleteCategoryModel);


        var findByGuidSpec = new FindByGUIDSpecification<Category>(
            deleteCategoryModel.CategoryId
        );

        Category category;
        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            category = await context.CategoryRepository.FirstByAsync(findByGuidSpec);
        }

        if (category is null) throw new CategoryNotFoundException("The category with the specified id does not exist.");


        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            await context.CategoryRepository.DeleteAsync(category);

            await context.ApplyChangesAsync();
            await context.CommitAsync();
        }
    }

    private async Task<HashSet<Facility>> GetAllFacilitiesByIds(HashSet<Guid> guids)
    {
        var findAllFacilitiesSpec = new FindAllFacilitiesByIds(guids);

        HashSet<Facility> facilities;
        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            facilities = (await context.FacilityRepository.SelectByAsync(findAllFacilitiesSpec)).ToHashSet();
        }

        if (guids.Count != facilities.Count)
        {
            var exceptionMessages = new StringBuilder();

            var missed = guids.ExceptBy(facilities.Select(facility => facility.Id), guid => guid);


            throw new FacilityNotFoundException(
                $"The facilities with ids '{string.Join(", ", missed)}' does not exist."
            );
        }

        return facilities;
    }
}
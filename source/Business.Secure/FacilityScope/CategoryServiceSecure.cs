#region

using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Business.Secure.CommonScope.Abstractions;
using Business.Secure.CommonScope.Context;
using Business.Secure.FacilityScope.Interfaces;
using Domain.CommonScope.Specification;
using Domain.FacilityScope.Actions;
using Domain.FacilityScope.Models;
using Domain.FacilityScope.Services;
using Domain.UserScope.ValueObjects;
using UnauthorizedAccessException = Domain.UserScope.Exceptions.UnauthorizedAccessException;

#endregion

namespace Business.Secure.FacilityScope;

public class CategoryServiceSecure : BaseUserAuthorization, ICategoryServiceSecure
{
    private readonly ICategoryService _categoryService;


    public CategoryServiceSecure(ICategoryService categoryService, IUserContext userContext) : base(userContext)
    {
        if (categoryService is null) throw new ArgumentNullException(nameof(categoryService));

        _categoryService = categoryService;
    }


    public async Task<Category> CreateCategoryAsync(CreateCategoryModel createCategoryModel)
    {
        return await _categoryService.CreateCategoryAsync(createCategoryModel);
    }

    public async Task<Category> GetCategoryAsync(Specification<Category> specification)
    {
        return await _categoryService.GetCategoryAsync(specification);
    }

    public async Task<ReadOnlyCollection<Category>> GetCategoriesAsync(Specification<Category> specification)
    {
        return await _categoryService.GetCategoriesAsync(specification);
    }

    public async Task<Category> UpdateCategoryAsync(UpdateCategoryModel updateCategoryModel)
    {
        return await _categoryService.UpdateCategoryAsync(updateCategoryModel);
    }

    public async Task DeleteCategoryAsync(DeleteCategoryModel deleteCategoryModel)
    {
        await _categoryService.DeleteCategoryAsync(deleteCategoryModel);
    }

    protected override void EnsureHasPermission()
    {
        var hasAccess = _userContext.User.Role.CheckPermission(Permission.CanMaintenanceCategory);
        if (hasAccess is false)
            throw new UnauthorizedAccessException(
                "The current user does not have permission to maintain categories."
            );
    }
}
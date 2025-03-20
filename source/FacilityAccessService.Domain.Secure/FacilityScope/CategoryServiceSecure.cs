#region

using System;
using System.Threading.Tasks;
using FacilityAccessService.Business.FacilityScope.Actions;
using FacilityAccessService.Business.FacilityScope.Models;
using FacilityAccessService.Business.FacilityScope.Services;
using FacilityAccessService.Business.UserScope.ValueObjects;
using FacilityAccessService.Domain.Secure.CommonScope.Abstractions;
using FacilityAccessService.Domain.Secure.CommonScope.Context;
using FacilityAccessService.Domain.Secure.FacilityScope.Interfaces;
using UnauthorizedAccessException = FacilityAccessService.Business.UserScope.Exceptions.UnauthorizedAccessException;

#endregion

namespace FacilityAccessService.Domain.Secure.FacilityScope
{
    public class CategoryServiceSecure : BaseServiceUserSecure, ICategoryServiceSecure
    {
        private readonly ICategoryService _categoryService;


        public CategoryServiceSecure(ICategoryService categoryService, IUserContext userContext) : base(userContext)
        {
            if (categoryService is null) throw new ArgumentNullException(nameof(categoryService));

            this._categoryService = categoryService;
        }


        public async Task<Category> CreateCategoryAsync(CreateCategoryModel createCategoryModel)
        {
            return await _categoryService.CreateCategoryAsync(createCategoryModel);
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
            bool hasAccess = _userContext.User.Role.CheckPermission(Permission.CanMaintenanceCategory);
            if (hasAccess is false)
            {
                throw new UnauthorizedAccessException(
                    "The current user does not have permission to maintain categories."
                );
            }
        }
    }
}
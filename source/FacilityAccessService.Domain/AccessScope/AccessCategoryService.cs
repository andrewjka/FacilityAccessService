using System;
using System.Threading.Tasks;
using FacilityAccessService.Business.AccessScope.Actions;
using FacilityAccessService.Business.AccessScope.Exceptions;
using FacilityAccessService.Business.AccessScope.Models;
using FacilityAccessService.Business.AccessScope.Repositories;
using FacilityAccessService.Business.AccessScope.Services;
using FacilityAccessService.Business.AccessScope.Specifications;
using FacilityAccessService.Business.CommonScope.Specifications.Generic;
using FacilityAccessService.Business.FacilityScope.Exceptions;
using FacilityAccessService.Business.FacilityScope.Models;
using FacilityAccessService.Business.FacilityScope.Repositories;
using FacilityAccessService.Business.UserScope.Exceptions;
using FacilityAccessService.Business.UserScope.Models;
using FacilityAccessService.Business.UserScope.Repositories;
using FacilityAccessService.Business.UserScope.Specifications;
using FluentValidation;

namespace FacilityAccessService.Domain.AccessScope
{
    public class AccessCategoryService : IAccessCategoryService
    {
        private IValidator<GrantAccessCategoryModel> _grantAccessVL;
        private IValidator<RevokeAccessCategoryModel> _revokeAccessVL;
        private IValidator<UpdateAccessCategoryModel> _updateAccessVL;
        private IValidator<UserCategory> _userCategoryVL;

        private IUserCategoryRepository _userCategoryRepository;

        private IUserRepository _userRepository;
        private ICategoryRepository _categoryRepository;


        public AccessCategoryService(
            IValidator<GrantAccessCategoryModel> grantAccessVL,
            IValidator<RevokeAccessCategoryModel> revokeAccessVL,
            IValidator<UpdateAccessCategoryModel> updateAccessVL,
            IValidator<UserCategory> userCategoryVl,
            IUserCategoryRepository userCategoryRepository,
            IUserRepository userRepository,
            ICategoryRepository categoryRepository
        )
        {
            if (grantAccessVL is null) throw new ArgumentNullException(nameof(grantAccessVL));
            if (revokeAccessVL is null) throw new ArgumentNullException(nameof(revokeAccessVL));
            if (updateAccessVL is null) throw new ArgumentNullException(nameof(updateAccessVL));
            if (userCategoryVl is null) throw new ArgumentNullException(nameof(userCategoryVl));

            if (userCategoryRepository is null) throw new ArgumentNullException(nameof(userCategoryRepository));
            if (userRepository is null) throw new ArgumentNullException(nameof(userRepository));
            if (categoryRepository is null) throw new ArgumentNullException(nameof(categoryRepository));

            this._grantAccessVL = grantAccessVL;
            this._revokeAccessVL = revokeAccessVL;
            this._updateAccessVL = updateAccessVL;
            this._userCategoryVL = userCategoryVl;
            this._userCategoryRepository = userCategoryRepository;
            this._userRepository = userRepository;
            this._categoryRepository = categoryRepository;
        }


        public async Task GrantAccessAsync(GrantAccessCategoryModel grantAccessModel)
        {
            _grantAccessVL.ValidateAndThrow(grantAccessModel);

            FindByIdSpecification userByIdSpec = new FindByIdSpecification(
                id: grantAccessModel.UserId
            );

            User user = await _userRepository.FirstByAsync(userByIdSpec);
            if (user is null)
            {
                throw new UserNotFoundException("The user with the specified id does not exist.");
            }

            FindByGUIDSpecification<Category> categoryByGuidSpec = new FindByGUIDSpecification<Category>(
                guid: grantAccessModel.CategoryId
            );

            Category category = await _categoryRepository.FirstByAsync(categoryByGuidSpec);
            if (category is null)
            {
                throw new CategoryNotFoundException("The category with the specified id does not exist.");
            }


            UserCategory userCategory = new UserCategory(
                userId: grantAccessModel.UserId,
                categoryId: grantAccessModel.CategoryId,
                accessPeriod: grantAccessModel.AccessPeriod
            );

            _userCategoryVL.ValidateAndThrow(userCategory);

            await _userCategoryRepository.CreateAsync(userCategory);
        }

        public async Task RevokeAccessAsync(RevokeAccessCategoryModel revokeAccessModel)
        {
            _revokeAccessVL.ValidateAndThrow(revokeAccessModel);


            FindUserCategorySpecification findUserCategorySpec = new FindUserCategorySpecification(
                userId: revokeAccessModel.UserId,
                categoryId: revokeAccessModel.CategoryId
            );

            UserCategory userCategory = await _userCategoryRepository.FirstByAsync(findUserCategorySpec);
            if (userCategory is null)
            {
                throw new UserCategoryNotFoundException("There is no such access to the category.");
            }

            await _userCategoryRepository.DeleteAsync(userCategory);
        }

        public async Task UpdateAccessAsync(UpdateAccessCategoryModel updateAccessModel)
        {
            _updateAccessVL.ValidateAndThrow(updateAccessModel);


            FindUserCategorySpecification findUserCategorySpec = new FindUserCategorySpecification(
                userId: updateAccessModel.UserId,
                categoryId: updateAccessModel.CategoryId
            );

            UserCategory userCategory = await _userCategoryRepository.FirstByAsync(findUserCategorySpec);
            if (userCategory is null)
            {
                throw new UserCategoryNotFoundException("There is no such access to the category.");
            }

            if (updateAccessModel.AccessPeriod is not null)
            {
                userCategory.ChangeAccessPeriod(updateAccessModel.AccessPeriod);
            }

            _userCategoryVL.ValidateAndThrow(userCategory);


            await _userCategoryRepository.UpdateAsync(userCategory);
        }
    }
}
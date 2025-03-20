using System;
using System.Threading.Tasks;
using FacilityAccessService.Business.AccessScope.Actions;
using FacilityAccessService.Business.AccessScope.Exceptions;
using FacilityAccessService.Business.AccessScope.Models;
using FacilityAccessService.Business.AccessScope.Services;
using FacilityAccessService.Business.AccessScope.Specifications;
using FacilityAccessService.Business.CommonScope.PersistenceContext;
using FacilityAccessService.Business.CommonScope.Specifications.Generic;
using FacilityAccessService.Business.FacilityScope.Exceptions;
using FacilityAccessService.Business.FacilityScope.Models;
using FacilityAccessService.Business.UserScope.Exceptions;
using FacilityAccessService.Business.UserScope.Models;
using FacilityAccessService.Business.UserScope.Specifications;
using FluentValidation;

namespace FacilityAccessService.Domain.AccessScope.Services
{
    public class AccessCategoryService : IAccessCategoryService
    {
        private readonly IValidator<GrantAccessCategoryModel> _grantAccessVL;
        private readonly IValidator<RevokeAccessCategoryModel> _revokeAccessVL;
        private readonly IValidator<UpdateAccessCategoryModel> _updateAccessVL;
        private readonly IValidator<UserCategory> _userCategoryVL;

        private readonly IPersistenceContextFactory _persistenceContextFactory;


        public AccessCategoryService(
            IValidator<GrantAccessCategoryModel> grantAccessVL,
            IValidator<RevokeAccessCategoryModel> revokeAccessVL,
            IValidator<UpdateAccessCategoryModel> updateAccessVL,
            IValidator<UserCategory> userCategoryVl,
            IPersistenceContextFactory persistenceContextFactory
        )
        {
            if (grantAccessVL is null) throw new ArgumentNullException(nameof(grantAccessVL));
            if (revokeAccessVL is null) throw new ArgumentNullException(nameof(revokeAccessVL));
            if (updateAccessVL is null) throw new ArgumentNullException(nameof(updateAccessVL));
            if (userCategoryVl is null) throw new ArgumentNullException(nameof(userCategoryVl));

            if (persistenceContextFactory is null) throw new ArgumentNullException(nameof(persistenceContextFactory));

            this._grantAccessVL = grantAccessVL;
            this._revokeAccessVL = revokeAccessVL;
            this._updateAccessVL = updateAccessVL;
            this._userCategoryVL = userCategoryVl;
            this._persistenceContextFactory = persistenceContextFactory;
        }


        public async Task GrantAccessAsync(GrantAccessCategoryModel grantAccessModel)
        {
            _grantAccessVL.ValidateAndThrow(grantAccessModel);

            FindByIdSpecification userByIdSpec = new FindByIdSpecification(
                id: grantAccessModel.UserId
            );

            User user;
            await using (IPersistenceContext context = await _persistenceContextFactory.CreatePersistenceContextAsync())
            {
                user = await context.UserRepository.FirstByAsync(userByIdSpec);
            }

            if (user is null)
            {
                throw new UserNotFoundException("The user with the specified id does not exist.");
            }

            FindByGUIDSpecification<Category> categoryByGuidSpec = new FindByGUIDSpecification<Category>(
                guid: grantAccessModel.CategoryId
            );

            Category category;
            await using (IPersistenceContext context = await _persistenceContextFactory.CreatePersistenceContextAsync())
            {
                category = await context.CategoryRepository.FirstByAsync(categoryByGuidSpec);
            }

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


            await using (IPersistenceContext context = await _persistenceContextFactory.CreatePersistenceContextAsync())
            {
                await context.UserCategoryRepository.UpdateAsync(userCategory);

                await context.CommitAsync();
            }
        }

        public async Task RevokeAccessAsync(RevokeAccessCategoryModel revokeAccessModel)
        {
            _revokeAccessVL.ValidateAndThrow(revokeAccessModel);


            FindUserCategorySpecification findUserCategorySpec = new FindUserCategorySpecification(
                userId: revokeAccessModel.UserId,
                categoryId: revokeAccessModel.CategoryId
            );

            UserCategory userCategory;
            await using (IPersistenceContext context = await _persistenceContextFactory.CreatePersistenceContextAsync())
            {
                userCategory = await context.UserCategoryRepository.FirstByAsync(findUserCategorySpec);

                await context.CommitAsync();
            }

            if (userCategory is null)
            {
                throw new UserCategoryNotFoundException("There is no such access to the category.");
            }

            await using (IPersistenceContext context = await _persistenceContextFactory.CreatePersistenceContextAsync())
            {
                await context.UserCategoryRepository.DeleteAsync(userCategory);

                await context.CommitAsync();
            }
        }

        public async Task UpdateAccessAsync(UpdateAccessCategoryModel updateAccessModel)
        {
            _updateAccessVL.ValidateAndThrow(updateAccessModel);


            FindUserCategorySpecification findUserCategorySpec = new FindUserCategorySpecification(
                userId: updateAccessModel.UserId,
                categoryId: updateAccessModel.CategoryId
            );

            UserCategory userCategory;
            await using (IPersistenceContext context = await _persistenceContextFactory.CreatePersistenceContextAsync())
            {
                userCategory = await context.UserCategoryRepository.FirstByAsync(findUserCategorySpec);
            }

            if (userCategory is null)
            {
                throw new UserCategoryNotFoundException("There is no such access to the category.");
            }

            if (updateAccessModel.AccessPeriod is not null)
            {
                userCategory.ChangeAccessPeriod(updateAccessModel.AccessPeriod);
            }

            _userCategoryVL.ValidateAndThrow(userCategory);


            await using (IPersistenceContext context = await _persistenceContextFactory.CreatePersistenceContextAsync())
            {
                await context.UserCategoryRepository.DeleteAsync(userCategory);

                await context.CommitAsync();
            }
        }
    }
}
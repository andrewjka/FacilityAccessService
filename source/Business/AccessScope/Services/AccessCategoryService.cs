#region

using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Domain.AccessScope.Actions;
using Domain.AccessScope.Exceptions;
using Domain.AccessScope.Models;
using Domain.AccessScope.Services;
using Domain.AccessScope.Specifications;
using Domain.CommonScope.PersistenceContext;
using Domain.CommonScope.Specification;
using Domain.CommonScope.Specifications.Generic;
using Domain.FacilityScope.Exceptions;
using Domain.FacilityScope.Models;
using Domain.UserScope.Exceptions;
using Domain.UserScope.Models;
using Domain.UserScope.Specifications;
using FluentValidation;

#endregion

namespace Business.AccessScope.Services;

public class AccessCategoryService : IAccessCategoryService
{
    private readonly IValidator<GrantAccessCategoryModel> _grantAccessVL;

    private readonly IPersistenceContextFactory _persistenceContextFactory;
    private readonly IValidator<RevokeAccessCategoryModel> _revokeAccessVL;
    private readonly IValidator<UpdateAccessCategoryModel> _updateAccessVL;
    private readonly IValidator<UserCategory> _userCategoryVL;


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

        _grantAccessVL = grantAccessVL;
        _revokeAccessVL = revokeAccessVL;
        _updateAccessVL = updateAccessVL;
        _userCategoryVL = userCategoryVl;
        _persistenceContextFactory = persistenceContextFactory;
    }


    public async Task GrantAccessAsync(GrantAccessCategoryModel grantAccessModel)
    {
        _grantAccessVL.ValidateAndThrow(grantAccessModel);

        var userByIdSpec = new FindByIdSpecification(
            grantAccessModel.UserId
        );

        User user;
        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            user = await context.UserRepository.FirstByAsync(userByIdSpec);
        }

        if (user is null) throw new UserNotFoundException("The user with the specified id does not exist.");

        var categoryByGuidSpec = new FindByGUIDSpecification<Category>(
            grantAccessModel.CategoryId
        );

        Category category;
        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            category = await context.CategoryRepository.FirstByAsync(categoryByGuidSpec);
        }

        if (category is null) throw new CategoryNotFoundException("The category with the specified id does not exist.");


        var userCategory = new UserCategory(
            grantAccessModel.UserId,
            grantAccessModel.CategoryId,
            grantAccessModel.AccessPeriod
        );

        _userCategoryVL.ValidateAndThrow(userCategory);


        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            await context.UserCategoryRepository.CreateAsync(userCategory);

            await context.ApplyChangesAsync();
            await context.CommitAsync();
        }
    }

    public async Task RevokeAccessAsync(RevokeAccessCategoryModel revokeAccessModel)
    {
        _revokeAccessVL.ValidateAndThrow(revokeAccessModel);


        var findUserCategorySpec = new FindUserCategorySpecification(
            revokeAccessModel.UserId,
            revokeAccessModel.CategoryId
        );

        UserCategory userCategory;
        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            userCategory = await context.UserCategoryRepository.FirstByAsync(findUserCategorySpec);
        }

        if (userCategory is null) throw new UserCategoryNotFoundException("There is no such access to the category.");

        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            await context.UserCategoryRepository.DeleteAsync(userCategory);

            await context.ApplyChangesAsync();
            await context.CommitAsync();
        }
    }

    public async Task UpdateAccessAsync(UpdateAccessCategoryModel updateAccessModel)
    {
        _updateAccessVL.ValidateAndThrow(updateAccessModel);


        var findUserCategorySpec = new FindUserCategorySpecification(
            updateAccessModel.UserId,
            updateAccessModel.CategoryId
        );

        UserCategory userCategory;
        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            userCategory = await context.UserCategoryRepository.FirstByAsync(findUserCategorySpec);
        }

        if (userCategory is null) throw new UserCategoryNotFoundException("There is no such access to the category.");

        if (updateAccessModel.AccessPeriod is not null) userCategory.ChangeAccessPeriod(updateAccessModel.AccessPeriod);

        _userCategoryVL.ValidateAndThrow(userCategory);


        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            await context.UserCategoryRepository.DeleteAsync(userCategory);

            await context.ApplyChangesAsync();
            await context.CommitAsync();
        }
    }

    public async Task<UserCategory> GetAccessAsync(Specification<UserCategory> specification)
    {
        UserCategory userCategory;
        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            userCategory = await context.UserCategoryRepository.FirstByAsync(specification);
        }

        return userCategory;
    }

    public async Task<ReadOnlyCollection<UserCategory>> GetAccessesAsync(
        Specification<UserCategory> specification)
    {
        ReadOnlyCollection<UserCategory> userCategories;
        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            userCategories = await context.UserCategoryRepository.SelectByAsync(specification);
        }

        return userCategories;
    }
}
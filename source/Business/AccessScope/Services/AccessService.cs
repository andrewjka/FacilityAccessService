#region

using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.AccessScope.Actions;
using Domain.AccessScope.Models;
using Domain.AccessScope.Services;
using Domain.AccessScope.Specifications;
using Domain.CommonScope.PersistenceContext;
using Domain.FacilityScope.Models;
using Domain.FacilityScope.Specifications;
using Event;
using FacilityAccessService.Event.Events;
using FluentValidation;

#endregion

namespace Business.AccessScope.Services;

public class AccessService : IAccessService
{
    private readonly IPersistenceContextFactory _persistenceContextFactory;

    private readonly IPublisher _publisher;
    IPassService _passService;
    private readonly IValidator<VerifyAccessModel> _verifyAccessVL;


    public AccessService(
        IValidator<VerifyAccessModel> verifyAccessVl,
        IPersistenceContextFactory persistenceContextFactory,
        IPublisher publisher,
        IPassService passService
    )
    {
        if (verifyAccessVl is null) throw new ArgumentNullException(nameof(verifyAccessVl));

        if (persistenceContextFactory is null) throw new ArgumentNullException(nameof(persistenceContextFactory));

        if (publisher is null) throw new ArgumentNullException(nameof(publisher));

        _verifyAccessVL = verifyAccessVl;
        _persistenceContextFactory = persistenceContextFactory;
        _publisher = publisher;
        _passService = passService;
    }

    public async Task<bool> VerifyAccessAsync(VerifyAccessModel verifyAccessModel)
    {
        _verifyAccessVL.ValidateAndThrow(verifyAccessModel);

        PassToken passToken = await _passService.VerifyAccessToken(verifyAccessModel.PassToken);

        string userId = passToken.UserId;


        var @event = new UserEnteredFacilityEvent(
            userId: userId,
            facilityId: verifyAccessModel.FacilityId
        );


        var userFacility = await FindUserFacilityAccessAsync(
            userId,
            verifyAccessModel.FacilityId
        );
        if (userFacility is not null)
        {
            await _publisher.PublishAsync(@event);

            return true;
        }

        var category = await FindAccessibleCategoryAsync(
            userId,
            verifyAccessModel.FacilityId
        );
        if (category is not null)
        {
            await _publisher.PublishAsync(@event);

            return true;
        }

        return false;
    }

    /// <summary>
    ///     Finds the user's direct access to the facility.
    /// </summary>
    private async Task<UserFacility> FindUserFacilityAccessAsync(string userId, Guid facilityId)
    {
        var findActiveUserFacilitySpec = new FindUserFacilitySpecification(
            userId,
            facilityId,
            true
        );

        UserFacility userFacility;
        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            userFacility = await context.UserFacilityRepository.FirstByAsync(findActiveUserFacilitySpec);
        }

        return userFacility;
    }

    /// <summary>
    ///     Finds the user's access to the facility through his available categories.
    /// </summary>
    private async Task<Category> FindAccessibleCategoryAsync(string userId, Guid facilityId)
    {
        var findUserCategorySpec = new FindUserCategorySpecification(
            userId,
            true
        );

        Category category;
        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            // Finds all categories for which the user has been granted access & access period has not yet expired
            var userCategories = await context.UserCategoryRepository.SelectByAsync(
                findUserCategorySpec
            );

            // Selects the IDs of categories
            var categoriesIds = userCategories.Select(userCategory => userCategory.CategoryId)
                .ToHashSet();

            // Finds among the user's categories the one that includes the facilityId
            var findCategoryByFacilityIdSpec =
                new FindCategoryByFacilityIdSpecification(
                    categoriesIds,
                    facilityId
                );

            category = await context.CategoryRepository.FirstByAsync(
                findCategoryByFacilityIdSpec
            );
        }

        return category;
    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using FacilityAccessService.Business.AccessScope.Actions.Abstractions;
using FacilityAccessService.Business.AccessScope.Models;
using FacilityAccessService.Business.AccessScope.Services;
using FacilityAccessService.Business.AccessScope.Specifications;
using FacilityAccessService.Business.CommonScope.PersistenceContext;
using FacilityAccessService.Business.FacilityScope.Models;
using FacilityAccessService.Business.FacilityScope.Specifications;
using FacilityAccessService.Event;
using FacilityAccessService.Event.Events;
using FluentValidation;

namespace FacilityAccessService.Domain.AccessScope.Services
{
    public class AccessControlService : IAccessControlService
    {
        private readonly IValidator<VerifyAccessModel> _verifyAccessVL;

        private readonly IPersistenceContextFactory _persistenceContextFactory;

        private IPublisher _publisher;


        public AccessControlService(
            IValidator<VerifyAccessModel> verifyAccessVl,
            IPersistenceContextFactory persistenceContextFactory,
            IPublisher publisher
        )
        {
            if (verifyAccessVl is null) throw new ArgumentNullException(nameof(verifyAccessVl));

            if (persistenceContextFactory is null) throw new ArgumentNullException(nameof(persistenceContextFactory));

            if (publisher is null) throw new ArgumentNullException(nameof(publisher));

            this._verifyAccessVL = verifyAccessVl;
            this._persistenceContextFactory = persistenceContextFactory;
            this._publisher = publisher;
        }

        public async Task<bool> VerifyAccessAsync(VerifyAccessModel verifyAccessModel)
        {
            _verifyAccessVL.ValidateAndThrow(verifyAccessModel);


            UserEnteredFacilityEvent @event = new UserEnteredFacilityEvent(
                UserId: verifyAccessModel.UserId,
                FacilityId: verifyAccessModel.FacilityId
            );


            UserFacility userFacility = await FindUserFacilityAccessAsync(
                userId: verifyAccessModel.UserId,
                facilityId: verifyAccessModel.FacilityId
            );
            if (userFacility is not null)
            {
                await _publisher.PublishAsync(@event);

                return true;
            }

            Category category = await FindAccessibleCategoryAsync(
                userId: verifyAccessModel.UserId,
                facilityId: verifyAccessModel.FacilityId
            );
            if (category is not null)
            {
                await _publisher.PublishAsync(@event);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Finds the user's direct access to the facility.
        /// </summary>
        private async Task<UserFacility> FindUserFacilityAccessAsync(string userId, Guid facilityId)
        {
            FindUserFacilitySpecification findActiveUserFacilitySpec = new FindUserFacilitySpecification(
                userId: userId,
                facilityId: facilityId,
                isOnlyActive: true
            );

            UserFacility userFacility;
            await using (IPersistenceContext context = await _persistenceContextFactory.CreatePersistenceContextAsync())
            {
                userFacility = await context.UserFacilityRepository.FirstByAsync(findActiveUserFacilitySpec);
            }

            return userFacility;
        }

        /// <summary>
        /// Finds the user's access to the facility through his available categories.
        /// </summary>
        private async Task<Category> FindAccessibleCategoryAsync(string userId, Guid facilityId)
        {
            FindUserCategorySpecification findUserCategorySpec = new FindUserCategorySpecification(
                userId: userId,
                isOnlyActive: true
            );

            Category category;
            await using (IPersistenceContext context = await _persistenceContextFactory.CreatePersistenceContextAsync())
            {
                // Finds all categories for which the user has been granted access & access period has not yet expired
                ReadOnlyCollection<UserCategory> userCategories = await context.UserCategoryRepository.SelectByAsync(
                    findUserCategorySpec
                );

                // Selects the IDs of categories
                HashSet<Guid> categoriesIds = userCategories.Select(userCategory => userCategory.CategoryId)
                    .ToHashSet();

                // Finds among the user's categories the one that includes the facilityId
                FindCategoryByFacilityIdSpecification findCategoryByFacilityIdSpec =
                    new FindCategoryByFacilityIdSpecification(
                        categoriesId: categoriesIds,
                        facilityId: facilityId
                    );

                category = await context.CategoryRepository.FirstByAsync(
                    findCategoryByFacilityIdSpec
                );
            }

            return category;
        }
    }
}
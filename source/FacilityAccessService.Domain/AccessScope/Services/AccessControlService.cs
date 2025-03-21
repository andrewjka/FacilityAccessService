using System;
using System.Threading.Tasks;
using FacilityAccessService.Business.AccessScope.Actions;
using FacilityAccessService.Business.AccessScope.Actions.Abstractions;
using FacilityAccessService.Business.AccessScope.Models;
using FacilityAccessService.Business.AccessScope.Services;
using FacilityAccessService.Business.AccessScope.Specifications;
using FacilityAccessService.Business.CommonScope.PersistenceContext;
using FacilityAccessService.Business.TerminalScope.Exceptions;
using FacilityAccessService.Business.TerminalScope.Models;
using FacilityAccessService.Business.TerminalScope.Specifications;
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


            FindUserFacilitySpecification findUserFacilitySpec = new FindUserFacilitySpecification(
                userId: verifyAccessModel.UserId,
                facilityId: verifyAccessModel.FacilityId
            );

            UserFacility userFacility;
            await using (IPersistenceContext context = await _persistenceContextFactory.CreatePersistenceContextAsync())
            {
                userFacility = await context.UserFacilityRepository.FirstByAsync(findUserFacilitySpec);
            }

            if (userFacility is null)
            {
                return false;
            }

            bool isAccessActive = userFacility.AccessPeriod.IsWithinAccessPeriod(DateOnly.FromDateTime(DateTime.Today));
            if (isAccessActive is true)
            {
                UserEnteredFacilityEvent @event = new UserEnteredFacilityEvent(
                    UserId: userFacility.UserId,
                    FacilityId: userFacility.FacilityId
                );

                await _publisher.PublishAsync(@event);

                return true;
            }

            return false;
        }
    }
}
using System;
using System.Threading.Tasks;
using FacilityAccessService.Business.AccessScope.Actions;
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

namespace FacilityAccessService.Domain.AccessScope
{
    public class AccessControlTerminalService : IAccessControlTerminalService
    {
        private readonly IValidator<VerifyAccessViaTerminalModel> _verifyAccessViaTerminalVL;

        private readonly IPersistenceContextFactory _persistenceContextFactory;

        private IPublisher _publisher;


        public AccessControlTerminalService(
            IValidator<VerifyAccessViaTerminalModel> verifyAccessViaTerminalVl,
            IPersistenceContextFactory persistenceContextFactory,
            IPublisher publisher
        )
        {
            if (verifyAccessViaTerminalVl is null) throw new ArgumentNullException(nameof(verifyAccessViaTerminalVl));

            if (persistenceContextFactory is null) throw new ArgumentNullException(nameof(persistenceContextFactory));

            if (publisher is null) throw new ArgumentNullException(nameof(publisher));

            this._verifyAccessViaTerminalVL = verifyAccessViaTerminalVl;
            this._persistenceContextFactory = persistenceContextFactory;
            this._publisher = publisher;
        }

        public async Task<bool> VerifyAccessAsync(VerifyAccessViaTerminalModel verifyAccessModel)
        {
            _verifyAccessViaTerminalVL.ValidateAndThrow(verifyAccessModel);


            FindByTerminalTokenSpecification guardByIdSpec = new FindByTerminalTokenSpecification(
                token: verifyAccessModel.TokenTerminal
            );

            Terminal terminal;
            await using (IPersistenceContext context = await _persistenceContextFactory.CreatePersistenceContext())
            {
                terminal = await context.TerminalRepository.FirstByAsync(guardByIdSpec);
            }

            if (terminal is null)
            {
                throw new TerminalTokenInvalidException("The terminal token is invalid.");
            }

            if (terminal.IsTokenExpired(DateOnly.FromDateTime(DateTime.Today)))
            {
                throw new TerminalTokenInvalidException("The terminal token is expired.");
            }


            FindUserFacilitySpecification findUserFacilitySpec = new FindUserFacilitySpecification(
                userId: verifyAccessModel.UserId,
                facilityId: verifyAccessModel.FacilityId
            );

            UserFacility userFacility;
            await using (IPersistenceContext context = await _persistenceContextFactory.CreatePersistenceContext())
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
                    FacilityId: userFacility.FacilityId.ToString(),
                    EnteredTime: DateTime.Now
                );

                await _publisher.PublishAsync(@event);

                return true;
            }

            return false;
        }
    }
}
using System;
using System.Threading.Tasks;
using FacilityAccessService.Business.AccessScope.Actions;
using FacilityAccessService.Business.AccessScope.Models;
using FacilityAccessService.Business.AccessScope.Services;
using FacilityAccessService.Business.AccessScope.Specifications;
using FacilityAccessService.Business.CommonScope.PersistenceContext;
using FacilityAccessService.Business.UserScope.Exceptions;
using FacilityAccessService.Business.UserScope.Models;
using FacilityAccessService.Business.UserScope.Specifications;
using FacilityAccessService.Business.UserScope.ValueObjects;
using FacilityAccessService.Event;
using FacilityAccessService.Event.Events;
using FluentValidation;

namespace FacilityAccessService.Domain.AccessScope
{
    public class AccessControlClientService : IAccessControlClientService
    {
        private readonly IValidator<VerifyAccessViaGuardModel> _verifyAccessViaGuardVL;

        private readonly IPersistenceContextFactory _persistenceContextFactory;

        private readonly IPublisher _publisher;


        public AccessControlClientService(
            IValidator<VerifyAccessViaGuardModel> verifyAccessViaGuardVL,
            IPersistenceContextFactory persistenceContextFactory,
            IPublisher publisher
        )
        {
            if (verifyAccessViaGuardVL is null) throw new ArgumentNullException(nameof(verifyAccessViaGuardVL));

            if (persistenceContextFactory is null) throw new ArgumentNullException(nameof(persistenceContextFactory));

            if (publisher is null) throw new ArgumentNullException(nameof(publisher));

            this._verifyAccessViaGuardVL = verifyAccessViaGuardVL;
            this._persistenceContextFactory = persistenceContextFactory;
            this._publisher = publisher;
        }

        public async Task<bool> VerifyAccessAsync(VerifyAccessViaGuardModel verifyAccessModel)
        {
            _verifyAccessViaGuardVL.ValidateAndThrow(verifyAccessModel);


            FindByIdSpecification guardByIdSpec = new FindByIdSpecification(
                id: verifyAccessModel.GuarderId
            );

            User guard;
            await using (IPersistenceContext context = await _persistenceContextFactory.CreatePersistenceContext())
            {
                guard = await context.UserRepository.FirstByAsync(guardByIdSpec);
            }

            if (guard is null)
            {
                throw new UserNotFoundException("The guarder with the specified id does not exist.");
            }

            //TODO: In general, this is business logic, but it is essentially put in Domain.Secure.
            // if (guard.Role.CheckPermission(Permission.CanCheckPass) is false)
            // {
            //     throw new UserHasNotPermissionException(
            //         $"The guarder with given id hasn't permission '{Permission.CanCheckPass.Name}' to verify user access."
            //     );
            // }


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
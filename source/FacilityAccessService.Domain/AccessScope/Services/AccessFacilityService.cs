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
    public class AccessFacilityService : IAccessFacilityService
    {
        private readonly IValidator<GrantAccessFacilityModel> _grantAccessVL;
        private readonly IValidator<RevokeAccessFacilityModel> _revokeAccessVL;
        private readonly IValidator<UpdateAccessFacilityModel> _updateAccessVL;
        private readonly IValidator<UserFacility> _userFacilityVL;

        private readonly IPersistenceContextFactory _persistenceContextFactory;


        public AccessFacilityService(
            IValidator<GrantAccessFacilityModel> grantAccessVL,
            IValidator<RevokeAccessFacilityModel> revokeAccessVL,
            IValidator<UpdateAccessFacilityModel> updateAccessVL,
            IValidator<UserFacility> userFacilityVL,
            IPersistenceContextFactory persistenceContextFactory
        )
        {
            if (grantAccessVL is null) throw new ArgumentNullException(nameof(grantAccessVL));
            if (revokeAccessVL is null) throw new ArgumentNullException(nameof(revokeAccessVL));
            if (updateAccessVL is null) throw new ArgumentNullException(nameof(updateAccessVL));
            if (userFacilityVL is null) throw new ArgumentNullException(nameof(userFacilityVL));

            if (persistenceContextFactory is null) throw new ArgumentNullException(nameof(persistenceContextFactory));

            this._grantAccessVL = grantAccessVL;
            this._revokeAccessVL = revokeAccessVL;
            this._updateAccessVL = updateAccessVL;
            this._userFacilityVL = userFacilityVL;
            this._persistenceContextFactory = persistenceContextFactory;
        }


        public async Task GrantAccessAsync(GrantAccessFacilityModel grantAccessModel)
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


            FindByGUIDSpecification<Facility> facilityByGuidSpecification = new FindByGUIDSpecification<Facility>(
                guid: grantAccessModel.FacilityId
            );

            Facility facility;
            await using (IPersistenceContext context = await _persistenceContextFactory.CreatePersistenceContextAsync())
            {
                facility = await context.FacilityRepository.FirstByAsync(facilityByGuidSpecification);
            }

            if (facility is null)
            {
                throw new FacilityNotFoundException("The facility with the specified id does not exist.");
            }


            UserFacility userFacility = new UserFacility(
                userId: grantAccessModel.UserId,
                facilityId: grantAccessModel.FacilityId,
                accessPeriod: grantAccessModel.AccessPeriod
            );

            _userFacilityVL.ValidateAndThrow(userFacility);


            await using (IPersistenceContext context = await _persistenceContextFactory.CreatePersistenceContextAsync())
            {
                await context.UserFacilityRepository.CreateAsync(userFacility);

                await context.CommitAsync();
            }
        }

        public async Task RevokeAccessAsync(RevokeAccessFacilityModel revokeAccessModel)
        {
            _revokeAccessVL.ValidateAndThrow(revokeAccessModel);


            FindUserFacilitySpecification findActiveUserFacilitySpec = new FindUserFacilitySpecification(
                userId: revokeAccessModel.UserId,
                facilityId: revokeAccessModel.FacilityId
            );

            UserFacility userFacility;
            await using (IPersistenceContext context = await _persistenceContextFactory.CreatePersistenceContextAsync())
            {
                userFacility = await context.UserFacilityRepository.FirstByAsync(findActiveUserFacilitySpec);
            }

            if (userFacility is null)
            {
                throw new UserFacilityNotFoundException("There is no such access to the facility.");
            }


            await using (IPersistenceContext context = await _persistenceContextFactory.CreatePersistenceContextAsync())
            {
                await context.UserFacilityRepository.DeleteAsync(userFacility);

                await context.CommitAsync();
            }
        }

        public async Task UpdateAccessAsync(UpdateAccessFacilityModel updateAccessModel)
        {
            _updateAccessVL.ValidateAndThrow(updateAccessModel);


            FindUserFacilitySpecification findActiveUserFacilitySpec = new FindUserFacilitySpecification(
                userId: updateAccessModel.UserId,
                facilityId: updateAccessModel.FacilityId
            );

            UserFacility userFacility;
            await using (IPersistenceContext context = await _persistenceContextFactory.CreatePersistenceContextAsync())
            {
                userFacility = await context.UserFacilityRepository.FirstByAsync(findActiveUserFacilitySpec);
            }

            if (userFacility is null)
            {
                throw new UserFacilityNotFoundException("There is no such access to the facility.");
            }

            if (updateAccessModel.AccessPeriod is not null)
            {
                userFacility.ChangeAccessPeriod(updateAccessModel.AccessPeriod);
            }

            _userFacilityVL.ValidateAndThrow(userFacility);


            await using (IPersistenceContext context = await _persistenceContextFactory.CreatePersistenceContextAsync())
            {
                await context.UserFacilityRepository.UpdateAsync(userFacility);

                await context.CommitAsync();
            }
        }
    }
}
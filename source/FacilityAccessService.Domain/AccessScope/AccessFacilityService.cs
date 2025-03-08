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
    public class AccessFacilityService : IAccessFacilityService
    {
        private IValidator<GrantAccessFacilityModel> _grantAccessVL;
        private IValidator<RevokeAccessFacilityModel> _revokeAccessVL;
        private IValidator<UpdateAccessFacilityModel> _updateAccessVL;
        private IValidator<UserFacility> _userFacilityVL;

        private IUserFacilityRepository _userFacilityRepository;

        private IUserRepository _userRepository;
        private IFacilityRepository _facilityRepository;


        public AccessFacilityService(
            IValidator<GrantAccessFacilityModel> grantAccessVL,
            IValidator<RevokeAccessFacilityModel> revokeAccessVL,
            IValidator<UpdateAccessFacilityModel> updateAccessVL,
            IValidator<UserFacility> userFacilityVL,
            IUserFacilityRepository userFacilityRepository,
            IUserRepository userRepository,
            IFacilityRepository facilityRepository
        )
        {
            if (grantAccessVL is null) throw new ArgumentNullException(nameof(grantAccessVL));
            if (revokeAccessVL is null) throw new ArgumentNullException(nameof(revokeAccessVL));
            if (updateAccessVL is null) throw new ArgumentNullException(nameof(updateAccessVL));
            if (userFacilityVL is null) throw new ArgumentNullException(nameof(userFacilityVL));

            if (userFacilityRepository is null) throw new ArgumentNullException(nameof(userFacilityRepository));
            if (userRepository is null) throw new ArgumentNullException(nameof(userRepository));
            if (facilityRepository is null) throw new ArgumentNullException(nameof(facilityRepository));

            this._grantAccessVL = grantAccessVL;
            this._revokeAccessVL = revokeAccessVL;
            this._updateAccessVL = updateAccessVL;
            this._userFacilityVL = userFacilityVL;
            this._userFacilityRepository = userFacilityRepository;
            this._userRepository = userRepository;
            this._facilityRepository = facilityRepository;
        }


        public async Task GrantAccessAsync(GrantAccessFacilityModel grantAccessModel)
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

            
            FindByGUIDSpecification<Facility> facilityByGuidSpecification = new FindByGUIDSpecification<Facility>(
                guid: grantAccessModel.FacilityId
            );

            Facility facility = await _facilityRepository.FirstByAsync(facilityByGuidSpecification);
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

            await _userFacilityRepository.CreateAsync(userFacility);
        }

        public async Task RevokeAccessAsync(RevokeAccessFacilityModel revokeAccessModel)
        {
            _revokeAccessVL.ValidateAndThrow(revokeAccessModel);


            FindUserFacilitySpecification findUserFacilitySpec = new FindUserFacilitySpecification(
                userId: revokeAccessModel.UserId,
                facilityId: revokeAccessModel.FacilityId
            );

            UserFacility userFacility = await _userFacilityRepository.FirstByAsync(findUserFacilitySpec);
            if (userFacility is null)
            {
                throw new UserFacilityNotFoundException("There is no such access to the facility.");
            }

            await _userFacilityRepository.DeleteAsync(userFacility);
        }

        public async Task UpdateAccessAsync(UpdateAccessFacilityModel updateAccessModel)
        {
            _updateAccessVL.ValidateAndThrow(updateAccessModel);


            FindUserFacilitySpecification findUserFacilitySpec = new FindUserFacilitySpecification(
                userId: updateAccessModel.UserId,
                facilityId: updateAccessModel.FacilityId
            );

            UserFacility userFacility = await _userFacilityRepository.FirstByAsync(findUserFacilitySpec);
            if (userFacility is null)
            {
                throw new UserFacilityNotFoundException("There is no such access to the facility.");
            }

            if (updateAccessModel.AccessPeriod is not null)
            {
                userFacility.ChangeAccessPeriod(updateAccessModel.AccessPeriod);
            }

            _userFacilityVL.ValidateAndThrow(userFacility);


            await _userFacilityRepository.UpdateAsync(userFacility);
        }
    }
}
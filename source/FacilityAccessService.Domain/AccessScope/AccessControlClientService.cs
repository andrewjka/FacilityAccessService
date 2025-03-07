using System;
using System.Threading.Tasks;
using FacilityAccessService.Business.AccessScope.Actions;
using FacilityAccessService.Business.AccessScope.Models;
using FacilityAccessService.Business.AccessScope.Repositories;
using FacilityAccessService.Business.AccessScope.Services;
using FacilityAccessService.Business.AccessScope.Specifications;
using FacilityAccessService.Business.CommonScope.Specifications.Generic;
using FacilityAccessService.Business.UserScope.Exceptions;
using FacilityAccessService.Business.UserScope.Models;
using FacilityAccessService.Business.UserScope.Repositories;
using FacilityAccessService.Business.UserScope.ValueObjects;
using FluentValidation;

namespace FacilityAccessService.Domain.AccessScope
{
    public class AccessControlClientService : IAccessControlClientService
    {
        private IValidator<VerifyAccessViaGuardModel> _verifyAccessViaGuardVL;

        private IUserFacilityRepository _userFacilityRepository;
        private IUserRepository _userRepository;


        public AccessControlClientService(
            IValidator<VerifyAccessViaGuardModel> verifyAccessViaGuardVL,
            IUserFacilityRepository userFacilityRepository,
            IUserRepository userRepository
        )
        {
            if (verifyAccessViaGuardVL is null) throw new ArgumentNullException(nameof(verifyAccessViaGuardVL));

            if (userFacilityRepository is null) throw new ArgumentNullException(nameof(userFacilityRepository));
            if (userRepository is null) throw new ArgumentNullException(nameof(userRepository));

            this._verifyAccessViaGuardVL = verifyAccessViaGuardVL;
            this._userFacilityRepository = userFacilityRepository;
            this._userRepository = userRepository;
        }

        public async Task<bool> VerifyAccessAsync(VerifyAccessViaGuardModel verifyAccessModel)
        {
            _verifyAccessViaGuardVL.ValidateAndThrow(verifyAccessModel);


            FindByIdSpecification<User> guardByIdSpec = new FindByIdSpecification<User>(
                guid: verifyAccessModel.GuarderId
            );

            User guard = await _userRepository.FirstByAsync(guardByIdSpec);
            if (guard is null)
            {
                throw new UserNotFoundException("The guarder with the specified id does not exist.");
            }

            if (guard.Role.CheckPermission(Permission.CanCheckPass) is false)
            {
                throw new UserHasNotPermissionException(
                    $"The guarder with given id hasn't permission '{Permission.CanCheckPass.Name}' to verify user access."
                );
            }


            FindUserFacilitySpecification findUserFacilitySpec = new FindUserFacilitySpecification(
                userId: verifyAccessModel.UserId,
                facilityId: verifyAccessModel.FacilityId
            );

            UserFacility userFacility = await _userFacilityRepository.FirstByAsync(findUserFacilitySpec);
            if (userFacility is not null)
            {
                return userFacility.AccessPeriod.IsWithinAccessPeriod(DateOnly.FromDateTime(DateTime.Today));
            }

            return false;
        }
    }
}
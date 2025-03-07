using System;
using System.Threading.Tasks;
using FacilityAccessService.Business.AccessScope.Actions;
using FacilityAccessService.Business.AccessScope.Models;
using FacilityAccessService.Business.AccessScope.Repositories;
using FacilityAccessService.Business.AccessScope.Services;
using FacilityAccessService.Business.AccessScope.Specifications;
using FacilityAccessService.Business.TerminalScope.Exceptions;
using FacilityAccessService.Business.TerminalScope.Models;
using FacilityAccessService.Business.TerminalScope.Repositories;
using FacilityAccessService.Business.TerminalScope.Specifications;
using FluentValidation;

namespace FacilityAccessService.Domain.AccessScope
{
    public class AccessControlTerminalService : IAccessControlTerminalService
    {
        private IValidator<VerifyAccessViaTerminalModel> _verifyAccessViaTerminalVL;

        private IUserFacilityRepository _userFacilityRepository;
        private ITerminalRepository _terminalRepository;


        public AccessControlTerminalService(
            IValidator<VerifyAccessViaTerminalModel> verifyAccessViaTerminalVl,
            IUserFacilityRepository userFacilityRepository,
            ITerminalRepository terminalRepository
        )
        {
            if (verifyAccessViaTerminalVl is null) throw new ArgumentNullException(nameof(verifyAccessViaTerminalVl));

            if (userFacilityRepository is null) throw new ArgumentNullException(nameof(userFacilityRepository));
            if (terminalRepository is null) throw new ArgumentNullException(nameof(terminalRepository));

            this._verifyAccessViaTerminalVL = verifyAccessViaTerminalVl;
            this._userFacilityRepository = userFacilityRepository;
            this._terminalRepository = terminalRepository;
        }

        public async Task<bool> VerifyAccessAsync(VerifyAccessViaTerminalModel verifyAccessModel)
        {
            _verifyAccessViaTerminalVL.ValidateAndThrow(verifyAccessModel);


            FindByTerminalTokenSpecification guardByIdSpec = new FindByTerminalTokenSpecification(
                token: verifyAccessModel.TokenTerminal
            );

            Terminal terminal = await _terminalRepository.FirstByAsync(guardByIdSpec);
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

            UserFacility userFacility = await _userFacilityRepository.FirstByAsync(findUserFacilitySpec);
            if (userFacility is not null)
            {
                return userFacility.AccessPeriod.IsWithinAccessPeriod(DateOnly.FromDateTime(DateTime.Today));
            }

            return false;
        }
    }
}
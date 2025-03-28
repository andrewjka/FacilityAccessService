#region

using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FacilityAccessService.Business.CommonScope.Specification;
using FacilityAccessService.Business.TerminalScope.Actions;
using FacilityAccessService.Business.TerminalScope.Models;
using FacilityAccessService.Business.TerminalScope.Services;
using FacilityAccessService.Business.UserScope.ValueObjects;
using FacilityAccessService.Domain.Secure.CommonScope.Abstractions;
using FacilityAccessService.Domain.Secure.CommonScope.Context;
using FacilityAccessService.Domain.Secure.TerminalScope.Interfaces;
using UnauthorizedAccessException = FacilityAccessService.Business.UserScope.Exceptions.UnauthorizedAccessException;

#endregion

namespace FacilityAccessService.Domain.Secure.TerminalScope
{
    public class TerminalServiceSecure : BaseUserAuthorization, ITerminalServiceSecure
    {
        private readonly ITerminalService _terminalService;


        public TerminalServiceSecure(ITerminalService terminalService, IUserContext userContext) : base(userContext)
        {
            if (terminalService is null) throw new ArgumentNullException(nameof(terminalService));

            this._terminalService = terminalService;
        }

        public async Task<Terminal> CreateTerminalAsync(CreateTerminalModel createTerminalModel)
        {
            return await _terminalService.CreateTerminalAsync(createTerminalModel);
        }

        public async Task<Terminal> GetTerminalAsync(Specification<Terminal> specification)
        {
            return await _terminalService.GetTerminalAsync(specification);
        }

        public async Task<ReadOnlyCollection<Terminal>> GetTerminalsAsync(Specification<Terminal> specification)
        {
            return await _terminalService.GetTerminalsAsync(specification);
        }

        public async Task<Terminal> UpdateTerminalAsync(UpdateTerminalModel updateTerminalModel)
        {
            return await _terminalService.UpdateTerminalAsync(updateTerminalModel);
        }

        public async Task DeleteTerminalAsync(DeleteTerminalModel deleteTerminalModel)
        {
            await _terminalService.DeleteTerminalAsync(deleteTerminalModel);
        }


        protected override void EnsureHasPermission()
        {
            bool hasAccess = _userContext.User.Role.CheckPermission(Permission.CanMaintenanceCategory);
            if (hasAccess is false)
            {
                throw new UnauthorizedAccessException(
                    "The current user does not have permission to maintain terminals."
                );
            }
        }
    }
}
#region

using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Business.Secure.CommonScope.Abstractions;
using Business.Secure.CommonScope.Context;
using Business.Secure.TerminalScope.Interfaces;
using Domain.CommonScope.Specification;
using Domain.TerminalScope.Actions;
using Domain.TerminalScope.Models;
using Domain.TerminalScope.Services;
using Domain.UserScope.ValueObjects;
using UnauthorizedAccessException = Domain.UserScope.Exceptions.UnauthorizedAccessException;

#endregion

namespace Business.Secure.TerminalScope;

public class TerminalServiceSecure : BaseUserAuthorization, ITerminalServiceSecure
{
    private readonly ITerminalService _terminalService;


    public TerminalServiceSecure(ITerminalService terminalService, IUserContext userContext) : base(userContext)
    {
        if (terminalService is null) throw new ArgumentNullException(nameof(terminalService));

        _terminalService = terminalService;
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
        var hasAccess = _userContext.User.Role.CheckPermission(Permission.CanMaintenanceCategory);
        if (hasAccess is false)
            throw new UnauthorizedAccessException(
                "The current user does not have permission to maintain terminals."
            );
    }
}
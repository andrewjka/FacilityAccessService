#region

using System;
using System.Threading.Tasks;
using Business.Secure.AccessScope.Interfaces;
using Business.Secure.CommonScope.Abstractions;
using Business.Secure.CommonScope.Context;
using Domain.AccessScope.Actions.Abstractions;
using Domain.AccessScope.Services;

#endregion

namespace Business.Secure.AccessScope;

public class AccessControlTerminalServiceSecure : BaseTerminalAuthorization, IAccessControlTerminalServiceSecure
{
    private readonly IAccessControlService _accessControl;


    public AccessControlTerminalServiceSecure(
        IAccessControlService accessControl,
        ITerminalContext terminalContext
    ) : base(terminalContext)
    {
        if (accessControl is null) throw new ArgumentNullException(nameof(accessControl));

        _accessControl = accessControl;
    }


    public async Task<bool> VerifyAccessAsync(VerifyAccessModel verifyAccessModel)
    {
        return await _accessControl.VerifyAccessAsync(verifyAccessModel);
    }
}
#region

using System;
using System.Threading.Tasks;
using Business.Secure.AccessScope.Interfaces;
using Business.Secure.CommonScope.Abstractions;
using Business.Secure.CommonScope.Context;
using Domain.AccessScope.Actions;
using Domain.AccessScope.Services;

#endregion

namespace Business.Secure.AccessScope;

public class AccessTerminalServiceSecure : BaseTerminalAuthorization, IAccessTerminalServiceSecure
{
    private readonly IAccessService _access;


    public AccessTerminalServiceSecure(
        IAccessService access,
        ITerminalContext terminalContext
    ) : base(terminalContext)
    {
        if (access is null) throw new ArgumentNullException(nameof(access));

        _access = access;
    }


    public async Task<bool> VerifyAccessAsync(VerifyAccessModel verifyAccessModel)
    {
        return await _access.VerifyAccessAsync(verifyAccessModel);
    }
}
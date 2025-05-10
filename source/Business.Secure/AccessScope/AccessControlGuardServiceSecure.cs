#region

using System;
using System.Threading.Tasks;
using Business.Secure.AccessScope.Interfaces;
using Business.Secure.CommonScope.Abstractions;
using Business.Secure.CommonScope.Context;
using Domain.AccessScope.Actions.Abstractions;
using Domain.AccessScope.Services;
using Domain.UserScope.ValueObjects;

#endregion

namespace Business.Secure.AccessScope;

public class AccessControlGuardServiceSecure : BaseUserAuthorization, IAccessControlGuardServiceSecure
{
    private readonly IAccessControlService _accessControl;


    public AccessControlGuardServiceSecure(
        IAccessControlService accessControl,
        IUserContext userContext
    ) : base(userContext)
    {
        if (accessControl is null) throw new ArgumentNullException(nameof(accessControl));

        _accessControl = accessControl;
    }


    public async Task<bool> VerifyAccessAsync(VerifyAccessModel verifyAccessModel)
    {
        return await _accessControl.VerifyAccessAsync(verifyAccessModel);
    }

    protected override void EnsureHasPermission()
    {
        var hasAccess = _userContext.User.Role.CheckPermission(Permission.CanCheckPass);
        if (hasAccess is false)
            throw new UnauthorizedAccessException(
                "The current user does not have permission to check user access to facility."
            );
    }
}
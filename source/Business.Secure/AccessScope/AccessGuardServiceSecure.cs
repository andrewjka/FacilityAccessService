#region

using System;
using System.Threading.Tasks;
using Business.Secure.AccessScope.Interfaces;
using Business.Secure.CommonScope.Abstractions;
using Business.Secure.CommonScope.Context;
using Domain.AccessScope.Actions;
using Domain.AccessScope.Services;
using Domain.UserScope.ValueObjects;

#endregion

namespace Business.Secure.AccessScope;

public class AccessGuardServiceSecure : BaseUserAuthorization, IAccessGuardServiceSecure
{
    private readonly IAccessService _access;


    public AccessGuardServiceSecure(
        IAccessService access,
        IUserContext userContext
    ) : base(userContext)
    {
        if (access is null) throw new ArgumentNullException(nameof(access));

        _access = access;
    }


    public async Task<bool> VerifyAccessAsync(VerifyAccessModel verifyAccessModel)
    {
        return await _access.VerifyAccessAsync(verifyAccessModel);
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
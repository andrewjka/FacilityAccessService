#region

using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Business.Secure.AccessScope.Context;
using Business.Secure.AccessScope.Interfaces;
using Business.Secure.CommonScope.Abstractions;
using Business.Secure.CommonScope.Context;
using Domain.AccessScope.Actions;
using Domain.AccessScope.Models;
using Domain.AccessScope.Services;
using Domain.CommonScope.Specification;
using Domain.UserScope.ValueObjects;

#endregion

namespace Business.Secure.AccessScope;

public class AccessFacilityServiceSecure : BaseUserAuthorization, IAccessFacilityServiceSecure
{
    private readonly IAccessFacilityService _accessFacility;

    private readonly IUserQueryContext _queryContext;


    public AccessFacilityServiceSecure(
        IAccessFacilityService accessFacility,
        IUserContext userContext,
        IUserQueryContext userQueryContext)
        : base(userContext)
    {
        if (accessFacility is null) throw new ArgumentNullException(nameof(accessFacility));
        if (userContext is null) throw new ArgumentNullException(nameof(userContext));
        if (userQueryContext is null) throw new ArgumentNullException(nameof(userQueryContext));

        _accessFacility = accessFacility;
        _queryContext = userQueryContext;
    }


    public async Task GrantAccessAsync(GrantAccessFacilityModel grantAccessModel)
    {
        EnsureHasMaintenancePermission();
        await _accessFacility.GrantAccessAsync(grantAccessModel);
    }

    public async Task RevokeAccessAsync(RevokeAccessFacilityModel revokeAccessModel)
    {
        EnsureHasMaintenancePermission();
        await _accessFacility.RevokeAccessAsync(revokeAccessModel);
    }

    public async Task UpdateAccessAsync(UpdateAccessFacilityModel updateAccessModel)
    {
        EnsureHasMaintenancePermission();
        await _accessFacility.UpdateAccessAsync(updateAccessModel);
    }

    public async Task<UserFacility> GetAccessAsync(Specification<UserFacility> specification)
    {
        EnsureHasSelectPermission();
        return await _accessFacility.GetAccessAsync(specification);
    }

    public async Task<ReadOnlyCollection<UserFacility>> GetAccessesAsync(
        Specification<UserFacility> specification
    )
    {
        EnsureHasSelectPermission();
        return await _accessFacility.GetAccessesAsync(specification);
    }

    protected override void EnsureHasPermission()
    {
    }

    protected void EnsureHasMaintenancePermission()
    {
        var hasAccess = _userContext.User.Role.CheckPermission(Permission.CanMaintenanceAccess);
        if (hasAccess is false)
            throw new UnauthorizedAccessException(
                "The current user does not have permission to maintenance access to categories."
            );
    }

    protected void EnsureHasSelectPermission()
    {
        var hasMaintenancePermission = _userContext.User.Role.CheckPermission(Permission.CanMaintenanceAccess);

        if (hasMaintenancePermission) return;


        if (string.IsNullOrEmpty(_queryContext.UserId)) throw new ArgumentNullException(nameof(_queryContext.UserId));

        var isSelfRequested = _userContext.User.Id == _queryContext.UserId;

        if (isSelfRequested) return;


        throw new UnauthorizedAccessException(
            "The current user does not have permission to maintenance access to facilities."
        );
    }
}
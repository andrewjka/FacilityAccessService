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

public class AccessCategoryServiceSecure : BaseUserAuthorization, IAccessCategoryServiceSecure
{
    private readonly IAccessCategoryService _accessCategory;

    private readonly IUserQueryContext _queryContext;


    public AccessCategoryServiceSecure(
        IAccessCategoryService accessCategory,
        IUserContext userContext,
        IUserQueryContext userQueryContext
    )
        : base(userContext)
    {
        if (accessCategory is null) throw new ArgumentNullException(nameof(accessCategory));
        if (userContext is null) throw new ArgumentNullException(nameof(userContext));
        if (userQueryContext is null) throw new ArgumentNullException(nameof(userQueryContext));


        _accessCategory = accessCategory;
        _queryContext = userQueryContext;
    }


    public async Task GrantAccessAsync(GrantAccessCategoryModel grantAccessModel)
    {
        EnsureHasMaintenancePermission();
        await _accessCategory.GrantAccessAsync(grantAccessModel);
    }

    public async Task RevokeAccessAsync(RevokeAccessCategoryModel revokeAccessModel)
    {
        EnsureHasMaintenancePermission();
        await _accessCategory.RevokeAccessAsync(revokeAccessModel);
    }

    public async Task UpdateAccessAsync(UpdateAccessCategoryModel updateAccessModel)
    {
        EnsureHasMaintenancePermission();
        await _accessCategory.UpdateAccessAsync(updateAccessModel);
    }

    public async Task<UserCategory> GetAccessAsync(Specification<UserCategory> specification)
    {
        EnsureHasSelectPermission();
        return await _accessCategory.GetAccessAsync(specification);
    }

    public async Task<ReadOnlyCollection<UserCategory>> GetAccessesAsync(
        Specification<UserCategory> specification
    )
    {
        EnsureHasSelectPermission();
        return await _accessCategory.GetAccessesAsync(specification);
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
            "The current user does not have permission to maintenance access to categories."
        );
    }
}
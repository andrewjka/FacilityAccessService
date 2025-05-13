#region

using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Business.Secure.CommonScope.Abstractions;
using Business.Secure.CommonScope.Context;
using Business.Secure.UserScope.Interfaces;
using Domain.CommonScope.Specification;
using Domain.UserScope.Actions;
using Domain.UserScope.Models;
using Domain.UserScope.Services;
using Domain.UserScope.ValueObjects;

#endregion

namespace Business.Secure.UserScope;

public class UserServiceSecure : BaseUserAuthorization, IUserServiceSecure
{
    private readonly IUserService _userService;


    public UserServiceSecure(IUserService userService, IUserContext userContext) : base(userContext)
    {
        _userService = userService;
    }


    /// <summary>
    ///     It is forbidden to create a new user, this is the responsibility of the internal workings of the service.
    /// </summary>
    /// <returns>Always returns exception</returns>
    /// <exception cref="UnauthorizedAccessException"></exception>
    public async Task<User> RegistryUserAsync(RegistryUserModel registryModel)
    {
        throw new UnauthorizedAccessException("Forbidden action.");
    }

    public async Task<User> GetUserAsync(Specification<User> specification)
    {
        return await _userService.GetUserAsync(specification);
    }

    public async Task<ReadOnlyCollection<User>> GetUsersAsync(Specification<User> specification)
    {
        return await _userService.GetUsersAsync(specification);
    }

    protected override void EnsureHasPermission()
    {
        var hasAccess = _userContext.User.Role.CheckPermission(Permission.CanMaintenanceUsers);
        if (hasAccess is false)
            throw new UnauthorizedAccessException(
                "The current user does not have permission to maintain users."
            );
    }
}
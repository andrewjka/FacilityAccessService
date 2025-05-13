#region

using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Domain.CommonScope.Specification;
using Domain.UserScope.Actions;
using Domain.UserScope.Models;

#endregion

namespace Domain.UserScope.Services;

/// <summary>
///     Describes the service for the main cases with the User entity.
/// </summary>
public interface IUserService
{
    /// <summary>
    ///     Registers a new User.
    /// </summary>
    public Task<User> RegistryUserAsync(RegistryUserModel registryModel);

    /// <summary>
    ///     Get the User by specification.
    /// </summary>
    public Task<User> GetUserAsync(Specification<User> specification);

    /// <summary>
    ///     Get all Users by specification.
    /// </summary>
    public Task<ReadOnlyCollection<User>> GetUsersAsync(Specification<User> specification);
}
#region

using Domain.CommonScope.Repositories;
using Domain.UserScope.Models;

#endregion

namespace Domain.UserScope.Repositories;

/// <summary>
///     Describes the repository for doing core operations with the User entity.
/// </summary>
public interface IUserRepository : IBaseRepository<User>
{
}
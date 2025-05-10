#region

using Domain.AccessScope.Models;
using Domain.CommonScope.Repositories;

#endregion

namespace Domain.AccessScope.Repositories;

/// <summary>
///     Describes the repository for doing core operations with the UserClientObject entity.
/// </summary>
public interface IUserFacilityRepository : IBaseRepository<UserFacility>
{
}
#region

using FacilityAccessService.Business.CommonScope.Repositories;
using FacilityAccessService.Business.UserScope.Models;

#endregion

namespace FacilityAccessService.Business.UserScope.Repositories
{
    /// <summary>
    /// Describes the repository for doing core operations with the User entity.
    /// </summary>
    public interface IUserRepository : IBaseRepository<User>
    {}
}
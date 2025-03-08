using FacilityAccessService.Business.CommonScope;
using FacilityAccessService.Business.UserScope.Models;

namespace FacilityAccessService.Business.UserScope.Repositories
{
    /// <summary>
    /// Describes the repository for doing core operations with the User entity.
    /// </summary>
    public interface IUserRepository : IBaseRepository<User>
    {
    }
}
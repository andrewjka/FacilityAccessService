using FacilityAccessService.Business.Common;
using FacilityAccessService.Business.User.Models;

namespace FacilityAccessService.Business.User.Repositories
{
    /// <summary>
    /// Describes the repository for doing core operations with the User entity.
    /// </summary>
    public interface IUserClientRepository : IBaseRepository<Models.User>
    {
    }
}
#region

using FacilityAccessService.Business.AccessScope.Models;
using FacilityAccessService.Business.CommonScope.Repositories;

#endregion

namespace FacilityAccessService.Business.AccessScope.Repositories
{
    /// <summary>
    /// Describes the repository for doing core operations with the UserClientObject entity.
    /// </summary>
    public interface IUserFacilityRepository : IBaseRepository<UserFacility>
    {}
}
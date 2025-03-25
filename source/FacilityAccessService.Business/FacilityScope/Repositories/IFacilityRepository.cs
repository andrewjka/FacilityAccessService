#region

using FacilityAccessService.Business.CommonScope.Repositories;
using FacilityAccessService.Business.FacilityScope.Models;

#endregion

namespace FacilityAccessService.Business.FacilityScope.Repositories
{
    /// <summary>
    /// Describes the repository for doing core operations with the Facility entity.
    /// </summary>
    public interface IFacilityRepository : IBaseRepository<Facility>
    {}
}
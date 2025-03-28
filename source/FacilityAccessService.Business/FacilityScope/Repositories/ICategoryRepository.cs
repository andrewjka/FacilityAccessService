#region

using FacilityAccessService.Business.CommonScope.Repositories;
using FacilityAccessService.Business.FacilityScope.Models;

#endregion

namespace FacilityAccessService.Business.FacilityScope.Repositories
{
    /// <summary>
    /// Describes the repository for doing core operations with the Category entity.
    /// </summary>
    public interface ICategoryRepository : IBaseRepository<Category>
    {}
}
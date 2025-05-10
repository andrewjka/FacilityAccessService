#region

using Domain.CommonScope.Repositories;
using Domain.FacilityScope.Models;

#endregion

namespace Domain.FacilityScope.Repositories;

/// <summary>
///     Describes the repository for doing core operations with the Facility entity.
/// </summary>
public interface IFacilityRepository : IBaseRepository<Facility>
{
}
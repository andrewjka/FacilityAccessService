#region

using Domain.CommonScope.Repositories;
using Domain.FacilityScope.Models;

#endregion

namespace Domain.FacilityScope.Repositories;

/// <summary>
///     Describes the repository for doing core operations with the Category entity.
/// </summary>
public interface ICategoryRepository : IBaseRepository<Category>
{
}
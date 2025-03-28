#region

using FacilityAccessService.Business.CommonScope.Repositories;
using FacilityAccessService.Business.TerminalScope.Models;

#endregion

namespace FacilityAccessService.Business.TerminalScope.Repositories
{
    /// <summary>
    /// Describes the repository for doing core operations with the Terminal entity.
    /// </summary>
    public interface ITerminalRepository : IBaseRepository<Terminal>
    {}
}
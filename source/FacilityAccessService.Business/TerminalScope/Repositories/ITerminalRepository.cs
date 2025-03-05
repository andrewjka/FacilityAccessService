using FacilityAccessService.Business.CommonScope;
using FacilityAccessService.Business.TerminalScope.Models;

namespace FacilityAccessService.Business.TerminalScope.Repositories
{
    /// <summary>
    /// Describes the repository for doing core operations with the Terminal entity.
    /// </summary>
    public interface ITerminalRepository : IBaseRepository<Models.Terminal>
    {
    }
}
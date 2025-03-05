using FacilityAccessService.Business.Common;
using FacilityAccessService.Business.Terminal.Models;

namespace FacilityAccessService.Business.Terminal.Repositories
{
    /// <summary>
    /// Describes the repository for doing core operations with the Terminal entity.
    /// </summary>
    public interface ITerminalRepository : IBaseRepository<Models.Terminal>
    {
    }
}
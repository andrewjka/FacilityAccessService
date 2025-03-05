using System.Threading.Tasks;
using FacilityAccessService.Business.TerminalScope.Actions;

namespace FacilityAccessService.Business.TerminalScope.Services
{
    /// <summary>
    /// Describes the service for the main cases with the Terminal entity.
    /// </summary>
    public interface ITerminalService
    {
        public Task<Models.Terminal> CreateTerminalAsync(CreateTerminalModel createTerminalModel);

        public Task<Models.Terminal> UpdateTerminalAsync(UpdateTerminalModel updateTerminalModel);

        public Task DeleteTerminalAsync(DeleteTerminalModel deleteTerminalModel);
    }
}
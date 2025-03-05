using System.Threading.Tasks;
using FacilityAccessService.Business.Terminal.Actions;

namespace FacilityAccessService.Business.Terminal.Services
{
    /// <summary>
    /// Describes the service for the main cases with the Terminal entity.
    /// </summary>
    public interface ITerminalService
    {
        public Task CreateTerminalAsync(CreateTerminalModel createTerminalModel);

        public Task UpdateTerminalAsync(UpdateTerminalModel updateTerminalModel);

        public Task DeleteTerminalAsync(DeleteTerminalModel deleteTerminalModel);
    }
}
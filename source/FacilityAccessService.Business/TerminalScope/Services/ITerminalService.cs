using System.Threading.Tasks;
using FacilityAccessService.Business.TerminalScope.Actions;
using FacilityAccessService.Business.TerminalScope.Models;

namespace FacilityAccessService.Business.TerminalScope.Services
{
    /// <summary>
    /// Describes the service for the main cases with the Terminal entity.
    /// </summary>
    public interface ITerminalService
    {
        /// <summary>
        /// Creates a new Terminal.
        /// </summary>
        public Task<Terminal> CreateTerminalAsync(CreateTerminalModel createTerminalModel);

        /// <summary>
        /// Updates the Terminal.
        /// </summary>
        public Task<Terminal> UpdateTerminalAsync(UpdateTerminalModel updateTerminalModel);

        /// <summary>
        /// Deletes the Terminal.
        /// </summary>
        public Task DeleteTerminalAsync(DeleteTerminalModel deleteTerminalModel);
    }
}
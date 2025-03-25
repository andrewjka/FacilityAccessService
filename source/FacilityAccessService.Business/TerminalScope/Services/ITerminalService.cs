#region

using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FacilityAccessService.Business.CommonScope.Specification;
using FacilityAccessService.Business.TerminalScope.Actions;
using FacilityAccessService.Business.TerminalScope.Models;

#endregion

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
        /// Get the Terminal by specification.
        /// </summary>
        public Task<Terminal> GetTerminalAsync(Specification<Terminal> specification);

        /// <summary>
        /// Get all Terminals by specification.
        /// </summary>
        public Task<ReadOnlyCollection<Terminal>> GetTerminalsAsync(Specification<Terminal> specification);

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
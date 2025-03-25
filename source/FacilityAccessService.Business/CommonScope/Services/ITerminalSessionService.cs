#region

using System.Threading.Tasks;
using FacilityAccessService.Business.TerminalScope.Models;
using FacilityAccessService.Business.TerminalScope.ValueObjects;

#endregion

namespace FacilityAccessService.Business.CommonScope.Services
{
    /// <summary>
    /// Describes a service for verifying Terminal session.
    /// </summary>
    public interface ITerminalSessionService
    {
        /// <summary>
        /// Validates the token session and returns the Terminal if successful.
        /// </summary>
        /// <param name="token">Session token.</param>
        Task<Terminal> ValidateTokenAsync(TerminalToken token);
    }
}
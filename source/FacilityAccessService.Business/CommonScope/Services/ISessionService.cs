using System.Threading.Tasks;
using FacilityAccessService.Business.UserScope.Models;

namespace FacilityAccessService.Business.CommonScope.Services
{
    /// <summary>
    /// Describes a service for verifying User session.
    /// </summary>
    public interface ISessionService
    {
        /// <summary>
        /// Validates the token session and returns the User if successful.
        /// </summary>
        /// <param name="token">Session token.</param>
        Task<(User user, bool isValidated)> ValidateTokenAsync(string token);
    }
}
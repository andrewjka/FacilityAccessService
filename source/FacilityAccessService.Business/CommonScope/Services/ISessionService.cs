using System.Threading.Tasks;
using FacilityAccessService.Business.UserScope.Models;

namespace FacilityAccessService.Business.CommonScope.Services
{
    /// <summary>
    /// Describes a service for verifying User session.
    /// </summary>
    public interface ISessionService
    {
        Task<(UserScope.Models.User userClient, bool isValidated)> ValidateTokenAsync(string token);
    }
}
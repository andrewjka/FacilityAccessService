using System.Threading.Tasks;
using FacilityAccessService.Business.User.Models;

namespace FacilityAccessService.Business.Common.Services
{
    /// <summary>
    /// Describes a service for verifying User session.
    /// </summary>
    public interface ISessionService
    {
        Task<(User.Models.User userClient, bool isValidated)> ValidateTokenAsync(string token);
    }
}
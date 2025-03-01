using System.Threading.Tasks;
using FacilityAccessService.Business.User.Models;

namespace FacilityAccessService.Business.Common.Services
{
    /// <summary>
    /// Describes a service for verifying userClient session.
    /// </summary>
    public interface ISessionService
    {
        Task<(UserClient userClient, bool isValidated)> ValidateTokenAsync(string token);
    }
}
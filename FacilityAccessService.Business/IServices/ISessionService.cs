using System.Threading.Tasks;
using FacilityAccessService.Business.Entities;

namespace FacilityAccessService.Business.IServices
{
    /// <summary>
    /// Describes a service for verifying userClient session.
    /// </summary>
    public interface ISessionService
    {
        Task<(UserClient userClient, bool isValidated)> ValidateTokenAsync(string token);
    }
}
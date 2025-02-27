using System.Threading.Tasks;

namespace FacilityAccessService.Business.IServices
{
    public interface ISessionService
    {
        Task<(string externalUserId, bool isValidated)> ValidateTokenAsync(string token);
    }
}
using System.Threading.Tasks;
using Domain.AccessScope.Models;
using Domain.UserScope.Models;

namespace Domain.AccessScope.Services;

public interface IPassService
{
    Task<string> GenerateAccessToken(string UserId);

    Task<PassToken> VerifyAccessToken(string jwtAccessToken);
}
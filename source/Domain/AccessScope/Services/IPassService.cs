using System.Threading.Tasks;
using Domain.AccessScope.Models;

namespace Domain.AccessScope.Services;

public interface IPassService
{
    Task<string> GenerateJwtPassToken(PassToken passToken);

    Task<bool> VerifyJwtPassToken(string jwtPassToken);
}
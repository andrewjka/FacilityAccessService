using Domain.AuthScope.Models;
using Domain.CommonScope.Repositories;

namespace Domain.AuthScope.Repositories;

public interface IRefreshTokenRepository : IBaseRepository<RefreshToken>
{
    
}
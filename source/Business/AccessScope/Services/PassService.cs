using System;
using System.Threading.Tasks;
using Domain.AccessScope.Exceptions;
using Domain.AccessScope.Models;
using Domain.AccessScope.Services;
using Domain.CommonScope.PersistenceContext;
using Domain.CommonScope.Services;
using Domain.CommonScope.ValueObjects;
using Domain.UserScope.Models;

namespace Business.AccessScope.Services;

public class PassService : IPassService
{
    private readonly ICacheService<PassToken> _passStorage;

    private readonly TimeSpan _ttlToken = TimeSpan.FromSeconds(32);


    public PassService(ICacheService<PassToken> passStorage, IPersistenceContextFactory persistenceContextFactory)
    {
        _passStorage = passStorage;
    }


    public async Task<string> GenerateAccessToken(string userId)
    {
        Token512Bit _token = Token512Bit.GenerateToken();

        PassToken passToken = new PassToken(userId, DateTime.Now + _ttlToken);

        await _passStorage.SetAsync(_token.GetHexFormat(), passToken, _ttlToken);

        return _token.GetHexFormat();
    }

    public async Task<PassToken> VerifyAccessToken(string jwtAccessToken)
    {
        PassToken? passToken = await _passStorage.GetAsync(jwtAccessToken);

        if (passToken == null)
        {
            throw new PassTokenNotFound("Token not found");
        }

        return passToken;
    }
}
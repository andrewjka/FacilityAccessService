using System;
using System.Threading.Tasks;
using Domain.AuthScope.Actions;
using Domain.AuthScope.Exceptions;
using Domain.AuthScope.Models;
using Domain.AuthScope.Services;
using Domain.AuthScope.Specifications;
using Domain.CommonScope.Helpers;
using Domain.CommonScope.PersistenceContext;
using Domain.CommonScope.Services;
using Domain.CommonScope.ValueObjects;
using Domain.UserScope.Models;
using Domain.UserScope.Specifications;

namespace Business.AuthScope.Services;

public class AuthUserService : IAuthUserService
{
    private readonly IPersistenceContextFactory _persistenceContextFactory;
    private readonly IJwtService<AuthData> _jwtService;
    private const string _authTokenKey = "f981a301c1a5c5b861b6613e8e1e78b90be4d5f9d1bd7707bb9f1382fffcbc52";

    public AuthUserService(
        IPersistenceContextFactory persistenceContextFactory,
        IJwtService<AuthData> jwtService
    )
    {
        if (persistenceContextFactory is null) throw new ArgumentNullException(nameof(persistenceContextFactory));

        _persistenceContextFactory = persistenceContextFactory;
        _jwtService = jwtService;
    }


    public async Task<AuthenticationResult> AuthenticateAsync(string email, string password)
    {
        User user;

        RefreshToken refreshToken;
        string accessToken;

        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            user = await context.UserRepository.FirstByAsync(new FindByEmailSpecification(email));
            if (user is null)
            {
                throw new AuthenticationFailedException("Authentication failed.");
            }

            string hashedPassword = PasswordHasher.Hash(password);
            if (user.Password != hashedPassword)
            {
                throw new AuthenticationFailedException("Authentication failed.");
            }

            refreshToken = new RefreshToken(user.Id, Token512Bit.GenerateToken());

            await context.RefreshTokenRepository.CreateAsync(refreshToken);

            await context.ApplyChangesAsync();
            await context.CommitAsync();
        }

        AuthData authData = new AuthData(user.Id, user.Role.Name, user.Email);
        accessToken = _jwtService.CreateToken(authData, _authTokenKey, TimeSpan.FromMinutes(16));

        return new AuthenticationResult(accessToken, refreshToken.Token);
    }

    public async Task<string> RefreshAccessTokenAsync(Token512Bit refreshToken)
    {
        RefreshToken _refreshToken;
        User user;

        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            _refreshToken =
                await context.RefreshTokenRepository.FirstByAsync(new FindByTokenSpecification(refreshToken));
        }

        if (_refreshToken is null)
        {
            throw new AuthenticationFailedException("Invalid refresh token.");
        }

        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            user = await context.UserRepository.FirstByAsync(new FindByIdSpecification(_refreshToken.UserId));
        }

        AuthData authData = new AuthData(user.Id, user.Role.Name, user.Email);
        return _jwtService.CreateToken(authData, _authTokenKey, TimeSpan.FromMinutes(16));
    }

    public async Task<User> ValidateTokenAsync(string token)
    {
        User user;
        AuthData authData = _jwtService.ValidateToken(token, _authTokenKey);

        if (authData is null)
        {
            throw new AuthenticationFailedException("Invalid token.");
        }

        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            user = await context.UserRepository.FirstByAsync(new FindByIdSpecification(authData.UserId));
        }

        return user;
    }

    public async Task SignOutAsync(Token512Bit refreshToken)
    {
        RefreshToken _refreshToken;

        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            _refreshToken =
                await context.RefreshTokenRepository.FirstByAsync(new FindByTokenSpecification(refreshToken));
        }

        if (_refreshToken is null)
        {
            throw new AuthenticationFailedException("Invalid refresh token.");
        }

        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            _refreshToken =
                await context.RefreshTokenRepository.FirstByAsync(new FindByTokenSpecification(refreshToken));

            await context.RefreshTokenRepository.DeleteAsync(_refreshToken);

            await context.ApplyChangesAsync();
            await context.CommitAsync();
        }
    }
}
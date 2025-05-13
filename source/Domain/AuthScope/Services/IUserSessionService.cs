#region

using System.Threading.Tasks;
using Domain.CommonScope.ValueObjects;
using Domain.UserScope.Models;

#endregion

namespace Domain.AuthScope.Services;

/// <summary>
///     Describes a service for verifying User session.
/// </summary>
public interface IUserSessionService
{
    /// <summary>
    /// Аутентифицирует пользователя и возвращает access token и refresh token.
    /// </summary>
    /// <param name="username">Имя пользователя.</param>
    /// <param name="password">Пароль пользователя.</param>
    /// <returns>JWT токен в случае успешной аутентификации, иначе null или исключение.</returns>
    Task<AuthenticationResult> AuthenticateAsync(string username, string password);

    /// <summary>
    /// Обновляет access token с помощью refresh token.
    /// </summary>
    /// <param name="refreshToken">Токен обновления.</param>
    /// <returns>Новый JWT токен.</returns>
    Task<string> RefreshAccessTokenAsync(Token512Bit refreshToken);

    /// <summary>
    /// Проверяет валидность JWT токена.
    /// </summary>
    /// <param name="token">JWT токен.</param>
    /// <returns>True, если токен валиден, иначе false.</returns>
    Task<User> ValidateTokenAsync(string token);
}

public record AuthenticationResult(Token512Bit AccessToken, Token512Bit RefreshToken);
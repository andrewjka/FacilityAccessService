using System;

namespace Domain.CommonScope.Services;

public interface IJwtService<T> where T : class
{
    /// <summary>
    /// Создает JWT токен с полезной нагрузкой типа T
    /// </summary>
    string CreateToken(T payload, string secret, TimeSpan lifetime);

    /// <summary>
    /// Проверяет валидность токена и возвращает данные
    /// </summary>
    T ValidateToken(string token, string secret);
}
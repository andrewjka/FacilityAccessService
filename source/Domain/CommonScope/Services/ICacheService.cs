using System;
using System.Threading.Tasks;

namespace Domain.CommonScope.Services;

public interface ICacheService<T>
{
    /// <summary>
    /// Устанавливает значение в кэш по указанному ключу с заданным сроком действия.
    /// </summary>
    /// <typeparam name="T">Тип значения.</typeparam>
    /// <param name="key">Ключ для хранения значения.</param>
    /// <param name="value">Значение для кэширования.</param>
    /// <param name="expiration">Срок действия кэша (время жизни).</param>
    /// <returns>Задача, представляющая асинхронную операцию.</returns>
    Task SetAsync(string key, T value, TimeSpan expiration);

    /// <summary>
    /// Получает значение из кэша по указанному ключу.
    /// </summary>
    /// <typeparam name="T">Тип значения.</typeparam>
    /// <param name="key">Ключ для получения значения.</param>
    /// <returns>Значение из кэша или null, если ключ не найден.</returns>
    Task<T?> GetAsync(string key);

    /// <summary>
    /// Удаляет значение из кэша по указанному ключу.
    /// </summary>
    /// <param name="key">Ключ для удаления.</param>
    /// <returns>Задача, представляющая асинхронную операцию.</returns>
    Task DeleteAsync(string key);
}
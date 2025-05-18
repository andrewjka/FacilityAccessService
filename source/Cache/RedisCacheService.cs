using Domain.CommonScope.Services;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Cache;

public class RedisCacheService<T> : ICacheService<T>
{
    private readonly IDatabase _database;

    public RedisCacheService(IDatabase database)
    {
        _database = database;
    }

    public async Task SetAsync(string key, T value, TimeSpan expiration)
    {
        if (string.IsNullOrEmpty(key))
            throw new ArgumentNullException(nameof(key));

        string serializedValue = JsonConvert.SerializeObject(value);
        await _database.StringSetAsync(key, serializedValue, expiration);
    }

    public async Task<T?> GetAsync(string key)
    {
        if (string.IsNullOrEmpty(key))
            throw new ArgumentNullException(nameof(key));

        string? serializedValue = await _database.StringGetAsync(key);
        if (serializedValue == null)
            return default;

        return JsonConvert.DeserializeObject<T>(serializedValue);
    }

    public async Task DeleteAsync(string key)
    {
        if (string.IsNullOrEmpty(key))
            throw new ArgumentNullException(nameof(key));

        await _database.KeyDeleteAsync(key);
    }
}
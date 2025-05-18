using Cache;
using Domain.CommonScope.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NRedisStack;
using NRedisStack.RedisStackCommands;
using StackExchange.Redis;

namespace Application.DependencyInjection.Cache;

public static class CacheModuleExtension
{
    public static void AddCacheModuleExtension(
        this IHostApplicationBuilder builder,
        string connectRedisString)
    {
        // 1. Регистрация ConnectionMultiplexer
        var redis = ConnectionMultiplexer.Connect(connectRedisString);
        builder.Services.AddSingleton<IConnectionMultiplexer>(redis);

        // 2. Регистрация Redis базы данных
        builder.Services.AddSingleton<IDatabase>(_ => redis.GetDatabase());
        
        // 4. Регистрация сервиса кэша
        builder.Services.AddSingleton(typeof(ICacheService<>), typeof(RedisCacheService<>));
    }
}
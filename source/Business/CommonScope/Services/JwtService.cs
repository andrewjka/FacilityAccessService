using System;
using System.Collections.Generic;
using Domain.CommonScope.Services;
using JWT.Algorithms;
using JWT.Builder;
using JWT.Exceptions;
using Newtonsoft.Json;

namespace Business.CommonScope.Services;

public class JwtService<T> : IJwtService<T> where T : class
{
    public string CreateToken(T payload, string secret, TimeSpan lifetime)
    {
        var claims = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(payload));
        var builder = JwtBuilder.Create()
            .WithAlgorithm(new HMACSHA256Algorithm())
            .WithSecret(secret)
            .AddClaim("exp", DateTimeOffset.UtcNow.Add(lifetime).ToUnixTimeSeconds());

        foreach (var claim in claims)
        {
            builder.AddClaim(claim.Key, claim.Value);
        }

        return builder.Encode();
    }

    public T ValidateToken(string token, string secret)
    {
        try
        {
            var json = JwtBuilder.Create()
                .WithAlgorithm(new HMACSHA256Algorithm())
                .WithSecret(secret)
                .MustVerifySignature()
                .Decode(token); // Декодируем в обертку

            return JsonConvert.DeserializeObject<T>(json);
        }
        catch (Exception ex) when (ex is TokenExpiredException
                                   || ex is SignatureVerificationException
                                   || ex is ArgumentException)
        {
            return null;
        }
    }

    private class JwtDataWrapper
    {
        public object data { get; set; }
    }
}
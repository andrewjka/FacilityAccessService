using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace FacilityAccessService.RestService.Authentication.Context
{
    public static class HttpRequestAuthentication
    {
        public const string SessionTokenKey = "sessionToken";


        public static string GetSessionToken(this HttpRequest httpRequest)
        {
            httpRequest.Headers.TryGetValue(SessionTokenKey, out StringValues values);

            return values.ToString();
        }
    }
}
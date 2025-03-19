using Microsoft.AspNetCore.Http;

namespace FacilityAccessService.RestService.Authentication.Context
{
    public static class HttpRequestAuthentication
    {
        public const string SessionTokenKey = "sessionToken";


        public static string GetSessionToken(this HttpRequest httpRequest)
        {
            httpRequest.Headers.TryGetValue(SessionTokenKey, out var values);

            return values.ToString();
        }
    }
}
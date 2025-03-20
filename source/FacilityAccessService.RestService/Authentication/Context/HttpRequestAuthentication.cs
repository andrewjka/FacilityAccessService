#region

using Microsoft.AspNetCore.Http;

#endregion

namespace FacilityAccessService.RestService.Authentication.Context
{
    public static class HttpRequestAuthentication
    {
        public const string SessionTokenKey = "sessionToken";

        public const string TerminalSessionTokenKey = "terminalToken";


        public static string GetSessionToken(this HttpRequest httpRequest)
        {
            httpRequest.Headers.TryGetValue(SessionTokenKey, out var values);

            return values.ToString();
        }

        public static string GetTerminalSessionToken(this HttpRequest httpRequest)
        {
            httpRequest.Headers.TryGetValue(TerminalSessionTokenKey, out var values);

            return values.ToString();
        }
    }
}
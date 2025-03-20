using FacilityAccessService.Business.TerminalScope.Models;
using FacilityAccessService.Business.UserScope.Models;
using Microsoft.AspNetCore.Http;


namespace FacilityAccessService.RestService.Authentication.Context
{
    public static class HttpContextAuthentication
    {
        public const string UserKey = "user";

        public const string TerminalKey = "terminal";


        public static User GetUserOrDefault(this HttpContext httpContext)
        {
            return httpContext.Items.TryGetValue(UserKey, out var user) ? user as User : null;
        }

        public static void SetUser(this HttpContext httpContext, User user)
        {
            httpContext.Items[UserKey] = user;
        }

        public static Terminal GetTerminalOrDefault(this HttpContext httpContext)
        {
            return httpContext.Items.TryGetValue(TerminalKey, out var terminal) ? terminal as Terminal : null;
        }

        public static void SetTerminal(this HttpContext httpContext, Terminal user)
        {
            httpContext.Items[TerminalKey] = user;
        }
    }
}
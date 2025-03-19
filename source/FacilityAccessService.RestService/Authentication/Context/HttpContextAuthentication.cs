using FacilityAccessService.Business.UserScope.Models;
using Microsoft.AspNetCore.Http;

namespace FacilityAccessService.RestService.Authentication.Context
{
    public static class HttpContextAuthentication
    {
        public const string UserKey = "user";


        public static User GetUserOrDefault(this HttpContext httpContext)
        {
            return httpContext.Items.TryGetValue(UserKey, out var user) ? user as User : null;
        }

        public static void SetUser(this HttpContext httpContext, User user)
        {
            httpContext.Items[UserKey] = user;
        }
    }
}
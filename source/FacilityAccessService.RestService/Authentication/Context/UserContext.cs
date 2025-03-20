#region

using FacilityAccessService.Business.UserScope.Models;
using FacilityAccessService.Domain.Secure.CommonScope.Context;
using Microsoft.AspNetCore.Http;

#endregion

namespace FacilityAccessService.RestService.Authentication.Context
{
    public class UserContext : IUserContext
    {
        public Business.UserScope.Models.User User { get; }

        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            User = httpContextAccessor.HttpContext.GetUserOrDefault();
        }
    }
}
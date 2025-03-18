using FacilityAccessService.Business.UserScope.Models;
using FacilityAccessService.Domain.Secure.CommonScope.Context;
using Microsoft.AspNetCore.Http;

namespace FacilityAccessService.RestService.Authentication.Context
{
    public class UserContext : IUserContext
    {
        public User User { get; }

        
        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            User = httpContextAccessor.HttpContext.GetUserOrDefault();
        }
    }
}
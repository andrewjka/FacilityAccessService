using FacilityAccessService.Domain.Secure.AccessScope.Context;
using Microsoft.AspNetCore.Http;

namespace FacilityAccessService.RestService.Common.Context
{
    public class UserQueryContext : IUserQueryContext
    {
        public string UserId { get; }

        public UserQueryContext(IHttpContextAccessor httpContextAccessor)
        {
            object rawUserId = (object)null;

            bool isContains = httpContextAccessor.HttpContext?.Request.RouteValues.TryGetValue(
                "user_id", out rawUserId
            ) ?? false;

            if (isContains)
            {
                UserId = (string)rawUserId;
            }
        }
    }
}
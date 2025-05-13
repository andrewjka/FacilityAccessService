using Business.Secure.AccessScope.Context;
using Microsoft.AspNetCore.Http;

namespace Presentation.Common.Context;

public class UserQueryContext : IUserQueryContext
{
    public UserQueryContext(IHttpContextAccessor httpContextAccessor)
    {
        var rawUserId = (object)null;

        var isContains = httpContextAccessor.HttpContext?.Request.RouteValues.TryGetValue(
            "user_id", out rawUserId
        ) ?? false;

        if (isContains) UserId = (string)rawUserId;
    }

    public string UserId { get; }
}
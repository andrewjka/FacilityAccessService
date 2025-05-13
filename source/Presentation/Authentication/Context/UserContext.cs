#region

using Business.Secure.CommonScope.Context;
using Domain.UserScope.Models;
using Microsoft.AspNetCore.Http;

#endregion

namespace Presentation.Authentication.Context;

public class UserContext : IUserContext
{
    public UserContext(IHttpContextAccessor httpContextAccessor)
    {
        User = httpContextAccessor.HttpContext.GetUserOrDefault();
    }

    public User User { get; }
}
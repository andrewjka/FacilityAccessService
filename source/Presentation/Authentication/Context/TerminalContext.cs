using Business.Secure.CommonScope.Context;
using Domain.TerminalScope.Models;
using Microsoft.AspNetCore.Http;

namespace Presentation.Authentication.Context;

public class TerminalContext : ITerminalContext
{
    public TerminalContext(IHttpContextAccessor httpContextAccessor)
    {
        Terminal = httpContextAccessor.HttpContext.GetTerminalOrDefault();
    }

    public Terminal Terminal { get; }
}
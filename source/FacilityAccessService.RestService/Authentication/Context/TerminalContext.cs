using FacilityAccessService.Business.TerminalScope.Models;
using FacilityAccessService.Domain.Secure.CommonScope.Context;
using Microsoft.AspNetCore.Http;

namespace FacilityAccessService.RestService.Authentication.Context
{
    public class TerminalContext : ITerminalContext
    {
        public Terminal Terminal { get; }

        public TerminalContext(IHttpContextAccessor httpContextAccessor)
        {
            Terminal = httpContextAccessor.HttpContext.GetTerminalOrDefault();
        }
    }
}
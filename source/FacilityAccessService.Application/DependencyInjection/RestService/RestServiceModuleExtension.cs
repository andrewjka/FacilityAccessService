using FacilityAccessService.Domain.Secure.CommonScope.Context;
using FacilityAccessService.RestService.Authentication.Context;
using FacilityAccessService.RestService.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FacilityAccessService.Application.DependencyInjection.RestService
{
    public static class RestServiceModuleExtension
    {
        public static void AddRestServiceModuleExtension(this IHostApplicationBuilder builder)
        {
            builder.Services.AddHttpContextAccessor();
            
            // Controllers
            builder.Services.AddControllers().AddApplicationPart(typeof(TerminalAccessControlApiController).Assembly);

            // Context
            builder.Services.AddScoped<IUserContext, UserContext>();
            builder.Services.AddScoped<ITerminalContext, TerminalContext>();
        }
    }
}
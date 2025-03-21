using FacilityAccessService.RestService.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FacilityAccessService.Application.DependencyInjection.RestService
{
    public static class RestServiceModuleExtension
    {
        public static void AddRestServiceModuleExtension(this IHostApplicationBuilder builder)
        {
            // Controllers
            builder.Services.AddControllers().AddApplicationPart(typeof(TerminalAccessControlApiController).Assembly);
        }
    }
}
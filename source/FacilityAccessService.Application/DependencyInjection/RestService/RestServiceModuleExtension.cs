using System.Text.Json.Serialization;
using FacilityAccessService.Domain.Secure.AccessScope.Context;
using FacilityAccessService.Domain.Secure.CommonScope.Context;
using FacilityAccessService.RestService.Authentication.Context;
using FacilityAccessService.RestService.Common.Context;
using FacilityAccessService.RestService.Controllers;
using FacilityAccessService.RestService.Mapping;
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
            builder.Services.AddControllers().AddApplicationPart(typeof(TerminalAccessControlApiController).Assembly)
                .AddNewtonsoftJson();

            // Context
            builder.Services.AddScoped<IUserQueryContext, UserQueryContext>();
            builder.Services.AddScoped<IUserContext, UserContext>();
            builder.Services.AddScoped<ITerminalContext, TerminalContext>();

            // AutoMapper
            builder.Services.AddAutoMapper(typeof(UserMapping).Assembly);
        }
    }
}
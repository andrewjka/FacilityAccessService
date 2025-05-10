using Business.Secure.AccessScope.Context;
using Business.Secure.CommonScope.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestService.Authentication.Context;
using RestService.Common.Context;
using RestService.Controllers;
using RestService.Mapping;

namespace Application.DependencyInjection.RestService;

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
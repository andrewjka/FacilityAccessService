using Business.Secure.AccessScope.Context;
using Business.Secure.CommonScope.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Presentation.Authentication.Context;
using Presentation.Common.Context;
using Presentation.Controllers;
using Presentation.Mapping;

namespace Application.DependencyInjection.Presentation;

public static class PresentationModuleExtension
{
    public static void AddPresentationModuleExtension(this IHostApplicationBuilder builder)
    {
        builder.Services.AddHttpContextAccessor();

        // Controllers
        builder.Services.AddControllers().AddApplicationPart(typeof(UserManagementApiController).Assembly)
            .AddNewtonsoftJson();

        // Context
        builder.Services.AddScoped<IUserQueryContext, UserQueryContext>();
        builder.Services.AddScoped<IUserContext, UserContext>();
        builder.Services.AddScoped<ITerminalContext, TerminalContext>();

        // AutoMapper
        builder.Services.AddAutoMapper(typeof(UserMapping).Assembly);
    }
}
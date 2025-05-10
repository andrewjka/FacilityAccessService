using Domain.CommonScope.Services;
using GrpcClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Application.DependencyInjection.GrpcClient;

public static class GrpcClientModuleExtension
{
    public static void AddGrpcClientModule(this IHostApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUserSessionService, UserSessionService>();
    }
}
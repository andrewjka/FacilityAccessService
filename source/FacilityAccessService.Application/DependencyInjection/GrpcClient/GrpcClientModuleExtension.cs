using FacilityAccessService.Business.CommonScope.Services;
using FacilityAccessService.GrpcClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FacilityAccessService.Application.DependencyInjection.GrpcClient
{
    public static class GrpcClientModuleExtension
    {
        public static void AddGrpcClientModule(this IHostApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUserSessionService, UserSessionService>();
        }
    }
}
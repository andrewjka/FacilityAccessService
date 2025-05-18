using Business.AccessScope.Services;
using Business.AuthScope.Services;
using Business.CommonScope.Services;
using Business.FacilityScope.Services;
using Business.TerminalScope.Services;
using Business.UserScope.Services;
using Domain.AccessScope.Services;
using Domain.AuthScope.Services;
using Domain.CommonScope.Services;
using Domain.FacilityScope.Services;
using Domain.TerminalScope.Services;
using Domain.UserScope.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Application.DependencyInjection.Business;

public static class BusinessModuleExtension
{
    public static void AddBusinessModule(this IHostApplicationBuilder builder)
    {
        // Services
        builder.Services.AddScoped<IUserService, UserService>();

        builder.Services.AddScoped<ITerminalService, TerminalService>();

        builder.Services.AddScoped<ICategoryService, CategoryService>();
        builder.Services.AddScoped<IFacilityService, FacilityService>();

        builder.Services.AddScoped<IAuthTerminalService, AuthTerminalService>();
        builder.Services.AddScoped<IAuthUserService, AuthUserService>();
        
        builder.Services.AddScoped<IPassService, PassService>();

        builder.Services.AddScoped(typeof(IJwtService<>), typeof(JwtService<>));

        builder.Services.AddScoped<IAccessCategoryService, AccessCategoryService>();
        builder.Services.AddScoped<IAccessFacilityService, AccessFacilityService>();
        builder.Services.AddScoped<IAccessService, AccessService>();
        builder.Services.AddScoped<IFacilityService, FacilityService>();
    }
}
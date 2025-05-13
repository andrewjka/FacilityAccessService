using Business.AccessScope.Services;
using Business.CommonScope.Services;
using Business.FacilityScope.Services;
using Business.TerminalScope.Services;
using Business.UserScope.Services;
using Domain.AccessScope.Services;
using Domain.AuthScope.Services;
using Domain.FacilityScope.Services;
using Domain.TerminalScope.Services;
using Domain.UserScope.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Application.DependencyInjection.Domain;

public static class DomainModuleExtension
{
    public static void AddDomainModule(this IHostApplicationBuilder builder)
    {
        // Services
        builder.Services.AddScoped<IUserService, UserService>();

        builder.Services.AddScoped<ITerminalService, TerminalService>();

        builder.Services.AddScoped<ICategoryService, CategoryService>();
        builder.Services.AddScoped<IFacilityService, FacilityService>();

        builder.Services.AddScoped<ITerminalSessionService, TerminalSessionService>();

        builder.Services.AddScoped<IAccessCategoryService, AccessCategoryService>();
        builder.Services.AddScoped<IAccessFacilityService, AccessFacilityService>();
        builder.Services.AddScoped<IAccessService, AccessService>();
        builder.Services.AddScoped<IFacilityService, FacilityService>();
    }
}
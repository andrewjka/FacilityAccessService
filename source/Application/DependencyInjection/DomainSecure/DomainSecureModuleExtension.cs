using Business.Secure.AccessScope;
using Business.Secure.AccessScope.Interfaces;
using Business.Secure.FacilityScope;
using Business.Secure.FacilityScope.Interfaces;
using Business.Secure.TerminalScope;
using Business.Secure.TerminalScope.Interfaces;
using Business.Secure.UserScope;
using Business.Secure.UserScope.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Application.DependencyInjection.DomainSecure;

public static class DomainSecureModuleExtension
{
    public static void AddDomainSecureModule(this IHostApplicationBuilder builder)
    {
        // Services
        builder.Services.AddScoped<ITerminalServiceSecure, TerminalServiceSecure>();

        builder.Services.AddScoped<ICategoryServiceSecure, CategoryServiceSecure>();
        builder.Services.AddScoped<IFacilityServiceSecure, FacilityServiceSecure>();

        builder.Services.AddScoped<IAccessCategoryServiceSecure, AccessCategoryServiceSecure>();
        builder.Services.AddScoped<IAccessFacilityServiceSecure, AccessFacilityServiceSecure>();
        builder.Services.AddScoped<IAccessControlGuardServiceSecure, AccessControlGuardServiceSecure>();
        builder.Services.AddScoped<IAccessControlTerminalServiceSecure, AccessControlTerminalServiceSecure>();

        builder.Services.AddScoped<IUserServiceSecure, UserServiceSecure>();
    }
}
using FacilityAccessService.Domain.Secure.AccessScope;
using FacilityAccessService.Domain.Secure.AccessScope.Interfaces;
using FacilityAccessService.Domain.Secure.FacilityScope;
using FacilityAccessService.Domain.Secure.FacilityScope.Interfaces;
using FacilityAccessService.Domain.Secure.TerminalScope;
using FacilityAccessService.Domain.Secure.TerminalScope.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FacilityAccessService.Application.DependencyInjection.DomainSecure
{
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
        }
    }
}
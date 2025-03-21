using FacilityAccessService.Business.AccessScope.Services;
using FacilityAccessService.Business.CommonScope.Services;
using FacilityAccessService.Business.FacilityScope.Services;
using FacilityAccessService.Business.TerminalScope.Services;
using FacilityAccessService.Business.UserScope.Services;
using FacilityAccessService.Domain.AccessScope.Services;
using FacilityAccessService.Domain.CommonScope.Services;
using FacilityAccessService.Domain.FacilityScope.Services;
using FacilityAccessService.Domain.TerminalScope.Services;
using FacilityAccessService.Domain.UserScope.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FacilityAccessService.Application.DependencyInjection.Domain
{
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
            builder.Services.AddScoped<IAccessControlService, AccessControlService>();
            builder.Services.AddScoped<IFacilityService, FacilityService>();
        }
    }
}
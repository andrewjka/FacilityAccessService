using FacilityAccessService.Business.CommonScope.PersistenceContext;
using FacilityAccessService.Persistence;
using FacilityAccessService.Persistence.CommonScope.PersistenceContext;
using FacilityAccessService.Persistence.UserScope.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FacilityAccessService.Application.DependencyInjection.Persistence
{
    public static class PersistenceModuleExtension
    {
        public static void AddPersistenceModule(
            this IHostApplicationBuilder builder,
            string connectMySqlString
        )
        {
            // PersistenceContextFactory
            builder.Services.AddScoped<IPersistenceContextFactory, PersistenceContextFactory>();


            // DbContext
            builder.Services.AddDbContext<AppDatabaseContext>(options => { options.UseMySQL(connectMySqlString); });


            // AutoMapper
            builder.Services.AddAutoMapper(typeof(UserMapping).Assembly);
        }
    }
}
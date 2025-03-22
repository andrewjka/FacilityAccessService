using System;
using FacilityAccessService.Application.DependencyInjection.Persistence.Hosted;
using FacilityAccessService.Business.CommonScope.PersistenceContext;
using FacilityAccessService.Persistence;
using FacilityAccessService.Persistence.CommonScope.PersistenceContext;
using FacilityAccessService.Persistence.UserScope.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

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
            builder.Services.AddDbContext<AppDatabaseContext>(options =>
            {
                options.UseMySql(connectMySqlString, new MySqlServerVersion(new Version(8, 4, 4)));
            });
            // builder.Services.AddDbContext<AppDatabaseContext>(options => { options.UseMySQL(connectMySqlString); });

            // AutoMapper
            builder.Services.AddAutoMapper(typeof(UserMapping).Assembly);

            // Startup tasks
            builder.Services.AddHostedService<MigrateDatabaseService>();
        }
    }
}
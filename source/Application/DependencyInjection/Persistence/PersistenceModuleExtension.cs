using System;
using Application.DependencyInjection.Persistence.Hosted;
using Domain.CommonScope.PersistenceContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence;
using Persistence.CommonScope.PersistenceContext;
using Persistence.UserScope.Mapping;

namespace Application.DependencyInjection.Persistence;

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

        // AutoMapper
        builder.Services.AddAutoMapper(typeof(UserMapping).Assembly);

        // Startup tasks
        builder.Services.AddHostedService<MigrateDatabaseService>();
    }
}
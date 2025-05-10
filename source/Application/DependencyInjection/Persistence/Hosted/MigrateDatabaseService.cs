using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence;
using Persistence.Migrations;

namespace Application.DependencyInjection.Persistence.Hosted;

public class MigrateDatabaseService : IHostedService
{
    private readonly IServiceProvider _serviceProvider;

    public MigrateDatabaseService(IServiceProvider serviceServiceProvider)
    {
        _serviceProvider = serviceServiceProvider;
    }


    public Task StartAsync(CancellationToken cancellationToken)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var context = scope.ServiceProvider.GetService<AppDatabaseContext>();


            var migrationService = new MigrationService(context);

            migrationService.ApplyMigrations();
        }

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
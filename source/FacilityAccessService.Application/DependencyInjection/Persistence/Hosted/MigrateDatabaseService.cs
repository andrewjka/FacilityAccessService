using System;
using System.Threading;
using System.Threading.Tasks;
using FacilityAccessService.Persistence;
using FacilityAccessService.Persistence.Migrations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FacilityAccessService.Application.DependencyInjection.Persistence.Hosted
{
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


                MigrationService migrationService = new MigrationService(context);

                migrationService.ApplyMigrations();
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
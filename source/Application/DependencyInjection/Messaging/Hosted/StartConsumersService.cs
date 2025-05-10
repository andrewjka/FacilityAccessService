using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using EasyNetQ;
using EasyNetQ.AutoSubscribe;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Application.DependencyInjection.Messaging.Hosted;

public class StartConsumersService : IHostedService
{
    private readonly IServiceProvider _serviceProvider;

    public StartConsumersService(IServiceProvider serviceServiceProvider)
    {
        _serviceProvider = serviceServiceProvider;
    }


    public Task StartAsync(CancellationToken cancellationToken)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var bus = scope.ServiceProvider.GetService<IBus>();

            var subscriber = new AutoSubscriber(bus, "facility_access_service");

            subscriber.Subscribe(Assembly.GetExecutingAssembly().GetTypes());
        }

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
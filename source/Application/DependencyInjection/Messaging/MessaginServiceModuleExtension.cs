using Application.DependencyInjection.Messaging.Hosted;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Application.DependencyInjection.Messaging;

public static class MessaginServiceModuleExtension
{
    public static void AddMessagingServiceModule(
        this IHostApplicationBuilder builder,
        string connectRabbitMqString
    )
    {
        // Startup tasks
        builder.Services.AddHostedService<StartConsumersService>();
    }
}
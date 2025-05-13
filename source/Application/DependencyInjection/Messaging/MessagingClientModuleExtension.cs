using Event;
using Messaging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Application.DependencyInjection.Messaging;

public static class MessagingModuleExtension
{
    public static void AddMessagingModule(
        this IHostApplicationBuilder builder,
        string connectRabbitMqString
    )
    {
        // Bus
        // builder.Services.AddEasyNetQ(connectRabbitMqString);

        // Publisher 
        builder.Services.AddSingleton<IPublisher, EmptyPublisher>();
    }
}
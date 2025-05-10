using EasyNetQ;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyInjection.Messaging;

public static class BusExtension
{
    public static void AddEasyNetQ(
        this IServiceCollection serviceCollection,
        string connectRabBitMqString
    )
    {
        var bus = RabbitHutch.CreateBus(connectRabBitMqString);

        serviceCollection.AddSingleton(bus);
    }
}
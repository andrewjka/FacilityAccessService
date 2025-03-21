using EasyNetQ;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FacilityAccessService.Application.DependencyInjection.MessagingClient
{
    public static class BusExtension
    {
        public static void AddEasyNetQ(
            this IServiceCollection serviceCollection,
            string connectRabBitMqString
        )
        {
            IBus bus = RabbitHutch.CreateBus(connectRabBitMqString);

            serviceCollection.AddSingleton<IBus>(bus);
        }
    }
}
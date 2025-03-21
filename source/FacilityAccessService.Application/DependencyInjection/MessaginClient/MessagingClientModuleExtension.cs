using FacilityAccessService.Event;
using FacilityAccessService.MessagingClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FacilityAccessService.Application.DependencyInjection.MessagingClient
{
    public static class MessagingClientModuleExtension
    {
        public static void AddMessagingClientModule(
            this IHostApplicationBuilder builder,
            string connectRabbitMqString
        )
        {
            // Bus
            builder.Services.AddEasyNetQ(connectRabbitMqString);

            // Publisher 
            builder.Services.AddSingleton<IPublisher, RabbitMqPublisher>();
        }
    }
}
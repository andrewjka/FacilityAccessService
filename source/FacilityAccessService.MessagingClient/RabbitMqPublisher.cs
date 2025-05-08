using System.Threading.Tasks;
using EasyNetQ;
using FacilityAccessService.Event;
using FacilityAccessService.MessagingContract;

namespace FacilityAccessService.MessagingClient
{
    public class RabbitMqPublisher : IPublisher
    {
        private readonly IBus _bus;


        public RabbitMqPublisher(IBus bus)
        {
            this._bus = bus;
        }


        public async Task PublishAsync<TEvent>(TEvent model) where TEvent : IEvent
        {
            await _bus.PubSub.PublishAsync(model);
        }
    }
}
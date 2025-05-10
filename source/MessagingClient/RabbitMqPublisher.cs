using System.Threading.Tasks;
using EasyNetQ;
using Event;
using MessagingContract;

namespace MessagingClient;

public class RabbitMqPublisher : IPublisher
{
    private readonly IBus _bus;


    public RabbitMqPublisher(IBus bus)
    {
        _bus = bus;
    }


    public async Task PublishAsync<TEvent>(TEvent model) where TEvent : IEvent
    {
        await _bus.PubSub.PublishAsync(model);
    }
}
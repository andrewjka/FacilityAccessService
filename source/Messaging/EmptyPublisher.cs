using System.Threading.Tasks;
using Event;
using MessagingContract;

namespace Messaging;

public class EmptyPublisher : IPublisher
{
    public Task PublishAsync<TEvent>(TEvent model) where TEvent : IEvent
    {
        return Task.CompletedTask;
    }
}
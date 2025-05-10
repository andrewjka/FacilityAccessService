using System.Threading.Tasks;
using MessagingContract;

namespace Event;

public interface IPublisher
{
    public Task PublishAsync<TEvent>(TEvent model) where TEvent : IEvent;
}
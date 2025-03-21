using System.Threading.Tasks;

namespace FacilityAccessService.Event
{
    public interface IPublisher
    {
        public Task PublishAsync<TEvent>(TEvent model) where TEvent : IEvent;
    }
}
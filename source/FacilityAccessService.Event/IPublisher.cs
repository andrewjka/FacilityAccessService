using System.Threading.Tasks;
using FacilityAccessService.MessagingContract;

namespace FacilityAccessService.Event
{
    public interface IPublisher
    {
        public Task PublishAsync<TEvent>(TEvent model) where TEvent : IEvent;
    }
}
using System.Threading.Tasks;

namespace FacilityAccessService.Event
{
    public interface IPublisher
    {
        public Task PublishAsync<T>(T model);
    }
}
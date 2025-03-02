using System.Threading.Tasks;

namespace FacilityAccessService.Event
{
    public interface IConsumer<T> where T: class
    {
        public Task ConsumeAsync(T model);
    }
}
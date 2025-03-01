using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FacilityAccessService.Business.Common.Specification;
using FacilityAccessService.Business.Terminal.Models;

namespace FacilityAccessService.Business.Common
{
    /// <summary>
    /// Describes a basic set of methods for all repositories.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseRepository<T> where T: class
    {
        public Task CreateAsync(T model);

        public Task UpdateAsync(T model);

        public Task<TerminalClient> FirstByAsync(Specification<T> specification);

        public Task<ReadOnlyCollection<T>> SelectByAsync(Specification<T> specification);
        
        public Task DeleteAsync(T model);
        
        public Task DeleteByAsync(Specification<T> specification);
    }
}
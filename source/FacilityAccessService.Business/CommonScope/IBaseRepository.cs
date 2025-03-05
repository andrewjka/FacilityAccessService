using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FacilityAccessService.Business.CommonScope.Specification;
using FacilityAccessService.Business.TerminalScope.Models;

namespace FacilityAccessService.Business.CommonScope
{
    /// <summary>
    /// Describes a basic set of methods for all repositories.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseRepository<T> where T: class
    {
        public Task CreateAsync(T model);

        public Task UpdateAsync(T model);

        public Task<TerminalScope.Models.Terminal> FirstByAsync(Specification<T> specification);

        public Task<ReadOnlyCollection<T>> SelectByAsync(Specification<T> specification);
        
        public Task DeleteAsync(T model);
        
        public Task DeleteByAsync(Specification<T> specification);
    }
}
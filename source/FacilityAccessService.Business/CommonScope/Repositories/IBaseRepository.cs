#region

using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FacilityAccessService.Business.CommonScope.Specification;

#endregion

namespace FacilityAccessService.Business.CommonScope.Repositories
{
    /// <summary>
    /// Describes a basic set of methods for all repositories.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseRepository<T> where T: class
    {
        public Task CreateAsync(T model);

        public Task UpdateAsync(T model);

        public Task<T> FirstByAsync(Specification<T> specification);
        public Task<ReadOnlyCollection<T>> SelectByAsync(Specification<T> specification);

        public Task DeleteAsync(T model);
        public Task<int> DeleteByAsync(Specification<T> specification);
    }
}
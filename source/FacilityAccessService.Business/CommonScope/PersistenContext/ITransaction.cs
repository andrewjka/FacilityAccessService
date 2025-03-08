using System;
using System.Threading.Tasks;

namespace FacilityAccessService.Business.CommonScope.PersistenceContext
{
    public interface ITransaction : IAsyncDisposable
    {
        public Task ApplyChangesAsync();
        public Task CommitAsync();
        public Task RollBackAsync();
    }
}
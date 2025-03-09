using System;
using System.Threading.Tasks;

namespace FacilityAccessService.Business.CommonScope.PersistenceContext
{
    /// <summary>
    /// Describes a data transaction.
    /// </summary>
    public interface ITransaction : IAsyncDisposable
    {
        /// <summary>
        /// Applies the changes but doesn't commit them.
        /// </summary>
        public Task ApplyChangesAsync();
        
        /// <summary>
        /// Commits the all changes.
        /// </summary>
        public Task CommitAsync();
        
        /// <summary>
        /// Reverts all changes.
        /// </summary>
        /// <returns></returns>
        public Task RollBackAsync();
    }
}
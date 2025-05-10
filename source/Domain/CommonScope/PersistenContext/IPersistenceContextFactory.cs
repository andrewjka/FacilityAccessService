#region

using System.Threading.Tasks;

#endregion

namespace Domain.CommonScope.PersistenceContext;

/// <summary>
///     Describes a small factory spawning a data interaction context (<see cref="IPersistenceContext" />).
/// </summary>
public interface IPersistenceContextFactory
{
    /// <summary>
    ///     Spawns a data interaction context.
    /// </summary>
    public Task<IPersistenceContext> CreatePersistenceContextAsync();
}
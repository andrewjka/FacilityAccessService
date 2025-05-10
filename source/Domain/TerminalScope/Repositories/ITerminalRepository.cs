#region

using Domain.CommonScope.Repositories;
using Domain.TerminalScope.Models;

#endregion

namespace Domain.TerminalScope.Repositories;

/// <summary>
///     Describes the repository for doing core operations with the Terminal entity.
/// </summary>
public interface ITerminalRepository : IBaseRepository<Terminal>
{
}
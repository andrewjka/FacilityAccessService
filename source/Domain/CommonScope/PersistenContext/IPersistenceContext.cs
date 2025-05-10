#region

using System;

#endregion

namespace Domain.CommonScope.PersistenceContext;

/// <summary>
///     Describes the context for interacting with the data.
/// </summary>
public interface IPersistenceContext : ITransaction, IUnitWork, IAsyncDisposable
{
}
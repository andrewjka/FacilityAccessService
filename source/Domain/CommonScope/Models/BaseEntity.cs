#region

using System;

#endregion

namespace Domain.CommonScope.Models;

/// <summary>
///     Describes the base class for all entities that have a unique identifier.
/// </summary>
public abstract class BaseEntity
{
    protected BaseEntity()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; protected set; }
}
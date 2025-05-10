using System;

namespace Persistence.CommonScope.Models;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
}
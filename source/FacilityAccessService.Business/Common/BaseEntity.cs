using System;

namespace FacilityAccessService.Business.Common
{
    /// <summary>
    /// Describes the base class for all entities that have a unique identifier.
    /// </summary>
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }
    }
}
using System;

namespace FacilityAccessService.Business.CommonScope.Models
{
    /// <summary>
    /// Describes the base class for all entities that have a unique identifier.
    /// </summary>
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }

        protected BaseEntity()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
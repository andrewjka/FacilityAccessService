#region

using System;

#endregion

namespace FacilityAccessService.Business.CommonScope.Models
{
    /// <summary>
    /// Describes the base class for all entities that have a unique identifier.
    /// </summary>
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; protected set; }
    }
}
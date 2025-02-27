using System;

namespace FacilityAccessService.Business.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }
    }
}
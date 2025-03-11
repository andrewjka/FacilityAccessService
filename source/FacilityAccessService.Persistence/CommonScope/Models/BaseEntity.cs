using System;

namespace FacilityAccessService.Persistence.CommonScope.Models
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
    }
}
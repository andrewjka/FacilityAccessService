using System;

namespace FacilityAccessService.Business.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }
    }
}
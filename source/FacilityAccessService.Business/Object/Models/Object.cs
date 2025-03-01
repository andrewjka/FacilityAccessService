using System;
using FacilityAccessService.Business.Common;

namespace FacilityAccessService.Business.Object.Models
{
    /// <summary>
    /// Describes a facility in the access control system.
    /// </summary>
    public class Object : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Object(Guid id, string name, string description)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
        }
    }
}
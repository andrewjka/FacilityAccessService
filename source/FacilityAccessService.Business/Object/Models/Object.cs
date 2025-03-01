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

        public Object(Guid uid, string name, string description)
        {
            this.Id = uid;
            this.Name = name;
            this.Description = description;
        }

        public void ChangeName(string name)
        {
            this.Name = name;
        }

        public void ChangeDescription(string description)
        {
            this.Description = description;
        }
    }
}
using System.Collections.ObjectModel;
using FacilityAccessService.Business.Common;

namespace FacilityAccessService.Business.Object.Models
{
    /// <summary>
    /// Describes a set of facilities in the access control system.
    /// </summary>
    public class Category : BaseEntity, IAccessedResouce
    {
        public string Name { get; private set; }
        public ReadOnlyCollection<Object> Objects { get; private set; }


        public Category(string name, ReadOnlyCollection<Object> objects) : base()
        {
            this.Name = name;
            this.Objects = objects;
        }

        public void ChangeName(string name)
        {
            this.Name = name;
        }
    }
}
using System.Collections.ObjectModel;
using FacilityAccessService.Business.CommonScope;

namespace FacilityAccessService.Business.ObjectScope.Models
{
    /// <summary>
    /// Describes a set of facilities in the access control system.
    /// </summary>
    public class Category : BaseEntity, IAccessedResource
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
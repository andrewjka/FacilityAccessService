using System.Collections.ObjectModel;
using FacilityAccessService.Business.CommonScope;

namespace FacilityAccessService.Business.FacilityScope.Models
{
    /// <summary>
    /// Describes a set of facilities in the access control system.
    /// </summary>
    public class Category : BaseEntity, IAccessedResource
    {
        public string Name { get; private set; }
        public ReadOnlyCollection<Facility> Objects { get; private set; }


        public Category(string name, ReadOnlyCollection<Facility> objects) : base()
        {
            this.Name = name;
            this.Objects = objects;
        }

        public void ChangeName(string name)
        {
            this.Name = name;
        }

        public void ChangeObjects(ReadOnlyCollection<Facility> objects)
        {
            this.Objects = objects;
        }
    }
}
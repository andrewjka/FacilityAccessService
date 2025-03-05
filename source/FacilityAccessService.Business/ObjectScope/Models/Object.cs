using FacilityAccessService.Business.CommonScope;

namespace FacilityAccessService.Business.ObjectScope.Models
{
    /// <summary>
    /// Describes a facility in the access control system.
    /// </summary>
    public class Object : BaseEntity, IAccessedResource
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Object(string name, string description) : base()
        {
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
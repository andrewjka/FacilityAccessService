using FacilityAccessService.Business.CommonScope.Models;

namespace FacilityAccessService.Business.FacilityScope.Models
{
    /// <summary>
    /// Describes a facility in the access control system.
    /// </summary>
    public class Facility : BaseEntity, IAccessedResource
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Facility(string name, string description) : base()
        {
            this.Name = name;
            this.Description = description;
        }
        
        /// <summary>
        /// Changes the Facility name.
        /// </summary>
        public void ChangeName(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Changes the Facility description.
        /// </summary>
        public void ChangeDescription(string description)
        {
            this.Description = description;
        }
    }
}
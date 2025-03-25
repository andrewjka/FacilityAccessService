#region

using System.Collections.Generic;
using FacilityAccessService.Business.CommonScope.Models;

#endregion

namespace FacilityAccessService.Business.FacilityScope.Models
{
    /// <summary>
    /// Describes a set of facilities in the access control system.
    /// </summary>
    public class Category : BaseEntity, IAccessedResource
    {
        public Category(string name, HashSet<Facility> facilities) : base()
        {
            this.Name = name;
            this.Facilities = facilities;
        }

        public string Name { get; private set; }
        public HashSet<Facility> Facilities { get; private set; }

        /// <summary>
        /// Changes the Category name.
        /// </summary>
        public void ChangeName(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Changes the set of object included in the category.
        /// </summary>
        public void ChangeFacilities(HashSet<Facility> facilities)
        {
            this.Facilities = facilities;
        }
    }
}
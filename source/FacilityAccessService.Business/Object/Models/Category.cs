using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FacilityAccessService.Business.Object.Models
{
    /// <summary>
    /// Describes a set of facilities in the access control system.
    /// </summary>
    public class Category
    {
        public string Name { get; private set; }
        public ReadOnlyCollection<Object> Objects { get; private set; }


        public Category(string name, ReadOnlyCollection<Object> objects)
        {
            this.Name = name;
            this.Objects = objects;
        }
    }
}
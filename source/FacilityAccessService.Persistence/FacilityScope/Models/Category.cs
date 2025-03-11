using System.Collections.Generic;
using FacilityAccessService.Persistence.CommonScope.Models;

namespace FacilityAccessService.Persistence.FacilityScope.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }


        public List<Facility> Facilities { get; set; }
    }
}
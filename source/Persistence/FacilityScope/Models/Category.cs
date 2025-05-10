using System.Collections.Generic;
using Persistence.CommonScope.Models;

namespace Persistence.FacilityScope.Models;

public class Category : BaseEntity
{
    public string Name { get; set; }


    public List<Facility> Facilities { get; set; }
}
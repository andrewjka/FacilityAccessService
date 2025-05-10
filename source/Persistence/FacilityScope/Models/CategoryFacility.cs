using System;

namespace Persistence.FacilityScope.Models;

public class CategoryFacility
{
    public Guid CategoryId { get; set; }
    public Guid FacilityId { get; set; }

    public Category Category { get; set; }
    public Facility Facility { get; set; }
}
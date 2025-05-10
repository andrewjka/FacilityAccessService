using Persistence.CommonScope.Models;

namespace Persistence.FacilityScope.Models;

public class Facility : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
}
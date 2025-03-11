using FacilityAccessService.Persistence.CommonScope.Models;

namespace FacilityAccessService.Persistence.FacilityScope.Models
{
    public class Facility : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
    }
}
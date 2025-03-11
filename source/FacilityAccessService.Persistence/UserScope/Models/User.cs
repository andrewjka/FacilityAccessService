using FacilityAccessService.Business.UserScope.ValueObjects;

namespace FacilityAccessService.Persistence.UserScope.Models
{
    public class User
    {
        public string Id { get; set; }
        public Role Role { get; set; }
    }
}
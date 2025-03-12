using FacilityAccessService.Business.UserScope.Models;

namespace FacilityAccessService.Domain.Secure.CommonScope.Context
{
    public interface IUserContext
    {
        public User User { get; }
    }
}
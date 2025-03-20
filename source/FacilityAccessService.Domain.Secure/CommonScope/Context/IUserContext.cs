#region

using FacilityAccessService.Business.UserScope.Models;

#endregion

namespace FacilityAccessService.Domain.Secure.CommonScope.Context
{
    public interface IUserContext
    {
        public User User { get; }
    }
}
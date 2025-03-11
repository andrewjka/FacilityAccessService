using AutoMapper;
using FacilityAccessService.Business.UserScope.Models;

namespace FacilityAccessService.Persistence.UserScope.Mapping
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<User, Models.User>();

            CreateMap<Models.User, User>()
                .ConstructUsing(from => new User(
                    from.Id,
                    from.Role)
                );
        }
    }
}
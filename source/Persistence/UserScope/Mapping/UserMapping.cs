using AutoMapper;
using Domain.UserScope.Models;

namespace Persistence.UserScope.Mapping;

public class UserMapping : Profile
{
    public UserMapping()
    {
        CreateMap<User, Models.User>();

        CreateMap<Models.User, User>()
            .ConstructUsing(from => new User(
                    from.Id,
                    from.Email,
                    from.Password,
                    from.Role
                )
            );
    }
}
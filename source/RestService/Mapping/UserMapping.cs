using AutoMapper;
using Domain.UserScope.Models;
using Domain.UserScope.ValueObjects;

namespace RestService.Mapping;

public class UserMapping : Profile
{
    public UserMapping()
    {
        CreateMap<User, Models.User>()
            .ForMember(dest => dest.Role, opt =>
                opt.MapFrom(src => src.Role.Name)
            );

        CreateMap<Models.User, User>()
            .ForMember(dest => dest.Role, opt =>
                opt.MapFrom(src => Role.GetRoleByName(src.Role.ToString()))
            ).ConstructUsing(src => new User(src.Id, Role.GetRoleByName(src.Role.ToString())));
    }
}
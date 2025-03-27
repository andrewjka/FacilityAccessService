using AutoMapper;
using FacilityAccessService.Business.UserScope.Models;
using FacilityAccessService.Business.UserScope.ValueObjects;


namespace FacilityAccessService.RestService.Mapping
{
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
}
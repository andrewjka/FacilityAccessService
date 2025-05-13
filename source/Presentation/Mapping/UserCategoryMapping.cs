using AutoMapper;
using Domain.AccessScope.Models;
using Domain.AccessScope.ValueObjects;

namespace Presentation.Mapping;

public class UserCategoryMapping : Profile
{
    public UserCategoryMapping()
    {
        CreateMap<UserCategory, Models.UserCategory>()
            .ForMember(dest => dest.StartDate, opt =>
                opt.MapFrom(src => src.AccessPeriod.StartDate))
            .ForMember(dest => dest.EndDate, opt =>
                opt.MapFrom(src => src.AccessPeriod.EndDate)
            );

        CreateMap<Models.UserCategory, UserCategory>()
            .ForMember(dest => dest.AccessPeriod, opt => opt.Ignore())
            .ConstructUsing(src => new UserCategory(
                src.UserId,
                src.CategoryId,
                new AccessPeriod(src.StartDate, src.EndDate))
            );
        ;
    }
}
using AutoMapper;
using Domain.AccessScope.Models;
using Domain.AccessScope.Services;
using Domain.AccessScope.ValueObjects;

namespace Presentation.Mapping;

public class UserFacilityMapping : Profile
{
    public UserFacilityMapping()
    {
        CreateMap<UserFacilityDto, Models.UserFacility>()
            .ForMember(dest => dest.StartDate, opt =>
                opt.MapFrom(src => src.AccessPeriod.StartDate))
            .ForMember(dest => dest.EndDate, opt =>
                opt.MapFrom(src => src.AccessPeriod.EndDate)
            );

        // CreateMap<Models.UserFacility, UserFacilityDto>()
        //     .ForMember(dest => dest.AccessPeriod, opt => opt.Ignore())
        //     .ConstructUsing(src => new UserFacility(
        //         src.UserId,
        //         src.FacilityId,
        //         new AccessPeriod(src.StartDate, src.EndDate))
        //     );
    }
}
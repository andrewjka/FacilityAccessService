using AutoMapper;
using FacilityAccessService.Business.AccessScope.Models;

namespace FacilityAccessService.Persistence.AccessScope.Mapping
{
    public class UserFacilityMapping : Profile
    {
        public UserFacilityMapping()
        {
            CreateMap<UserFacility, Models.UserFacility>()
                .ForMember(dest => dest.User, opt =>
                    opt.Ignore())
                .ForMember(dest => dest.Facility, opt =>
                    opt.Ignore());


            CreateMap<Models.UserFacility, UserFacility>()
                .ConstructUsing(from => new UserFacility(
                    from.UserId,
                    from.FacilityId,
                    from.AccessPeriod)
                );
        }
    }
}
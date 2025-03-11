using AutoMapper;
using FacilityAccessService.Business.AccessScope.Models;

namespace FacilityAccessService.Persistence.AccessScope.Mapping
{
    public class UserCategoryMapping : Profile
    {
        public UserCategoryMapping()
        {
            CreateMap<UserCategory, Models.UserCategory>()
                .ForMember(dest => dest.User, opt =>
                    opt.Ignore())
                .ForMember(dest => dest.Category, opt =>
                    opt.Ignore());


            CreateMap<Models.UserCategory, UserCategory>()
                .ConstructUsing(from => new UserCategory(
                    from.UserId,
                    from.CategoryId,
                    from.AccessPeriod)
                );
        }
    }
}
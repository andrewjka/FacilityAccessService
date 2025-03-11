using AutoMapper;
using FacilityAccessService.Business.AccessScope.Models;

namespace FacilityAccessService.Persistence.AccessScope.Mapping
{
    public class UserCategoryMapping : Profile
    {
        public UserCategoryMapping()
        {
            CreateMap<UserCategory, Models.UserCategory>();
            CreateMap<Models.UserCategory, UserCategory>();
        }
    }
}
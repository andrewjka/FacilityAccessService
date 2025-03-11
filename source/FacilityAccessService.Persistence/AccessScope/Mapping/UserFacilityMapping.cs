using AutoMapper;
using FacilityAccessService.Business.AccessScope.Models;

namespace FacilityAccessService.Persistence.AccessScope.Mapping
{
    public class UserFacilityMapping : Profile
    {
        public UserFacilityMapping()
        {
            CreateMap<UserFacility, Models.UserFacility>();
            CreateMap<Models.UserFacility, UserFacility>();
        }
    }
}
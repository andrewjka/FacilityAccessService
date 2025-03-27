using AutoMapper;
using FacilityAccessService.Business.FacilityScope.Models;

namespace FacilityAccessService.RestService.Mapping
{
    public class FacilityMapping : Profile
    {
        public FacilityMapping()
        {
            CreateMap<Facility, Models.Facility>();
            CreateMap<Models.Facility, Facility>();
        }
    }
}
using AutoMapper;
using Domain.FacilityScope.Models;

namespace RestService.Mapping;

public class FacilityMapping : Profile
{
    public FacilityMapping()
    {
        CreateMap<Facility, Models.Facility>();
        CreateMap<Models.Facility, Facility>();
    }
}
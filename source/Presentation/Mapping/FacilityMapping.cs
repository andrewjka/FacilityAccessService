using AutoMapper;
using Domain.FacilityScope.Models;

namespace Presentation.Mapping;

public class FacilityMapping : Profile
{
    public FacilityMapping()
    {
        CreateMap<Facility, Models.Facility>();
        CreateMap<Models.Facility, Facility>();
    }
}
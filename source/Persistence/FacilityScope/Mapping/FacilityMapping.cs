using AutoMapper;
using Domain.FacilityScope.Models;

namespace Persistence.FacilityScope.Mapping;

public class FacilityMapping : Profile
{
    public FacilityMapping()
    {
        CreateMap<Facility, Models.Facility>();
        CreateMap<Models.Facility, Facility>()
            .ConstructUsing(from => new Facility(
                from.Name,
                from.Description)
            );
    }
}
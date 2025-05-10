using System.Collections.Generic;
using AutoMapper;
using Domain.FacilityScope.Models;

namespace Persistence.FacilityScope.Mapping;

public class CategoryMapping : Profile
{
    public CategoryMapping()
    {
        CreateMap<Category, Models.Category>();
        CreateMap<Models.Category, Category>()
            .ConstructUsing(from => new Category(
                from.Name,
                new HashSet<Facility>())
            );
    }
}
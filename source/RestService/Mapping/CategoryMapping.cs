using AutoMapper;
using Domain.FacilityScope.Models;

namespace RestService.Mapping;

public class CategoryMapping : Profile
{
    public CategoryMapping()
    {
        CreateMap<Category, Models.Category>();
        CreateMap<Models.Category, Category>();
    }
}
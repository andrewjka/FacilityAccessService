using AutoMapper;
using FacilityAccessService.Business.FacilityScope.Models;

namespace FacilityAccessService.Persistence.FacilityScope.Mapping
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<Category, Models.Category>();
            CreateMap<Models.Category, Category>();
        }
    }
}
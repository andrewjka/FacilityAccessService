using AutoMapper;
using FacilityAccessService.Business.FacilityScope.Models;

namespace FacilityAccessService.RestService.Mapping
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
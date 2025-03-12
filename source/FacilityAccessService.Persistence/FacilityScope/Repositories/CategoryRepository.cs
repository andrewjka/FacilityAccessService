using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FacilityAccessService.Business.CommonScope.Specification;
using FacilityAccessService.Business.FacilityScope.Repositories;
using FacilityAccessService.Persistence.CommonScope.Repositories;
using FacilityAccessService.Persistence.FacilityScope.Models;
using Microsoft.EntityFrameworkCore;

namespace FacilityAccessService.Persistence.FacilityScope.Repositories
{
    public class CategoryRepository : BaseRepository<Category, Business.FacilityScope.Models.Category>,
        ICategoryRepository
    {
        public CategoryRepository(AppDatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<Business.FacilityScope.Models.Category> FirstByAsync(
            Specification<Business.FacilityScope.Models.Category> specification)
        {
            IQueryable<Category> queryable = _context.Categories;

            BuildQueryBasedSpecification(ref queryable, specification);


            var categorydb = await queryable.FirstOrDefaultAsync();

            return _mapper.Map<Business.FacilityScope.Models.Category>(categorydb);
        }

        public override async Task<ReadOnlyCollection<Business.FacilityScope.Models.Category>> SelectByAsync(
            Specification<Business.FacilityScope.Models.Category> specification)
        {
            IQueryable<Category> queryable = _context.Categories;

            BuildQueryBasedSpecification(ref queryable, specification);


            var categories = await queryable.ToListAsync();

            return _mapper.Map<List<Business.FacilityScope.Models.Category>>(categories).AsReadOnly();
        }

        public override async Task<int> DeleteByAsync(
            Specification<Business.FacilityScope.Models.Category> specification)
        {
            IQueryable<Category> queryable = _context.Categories;

            BuildQueryBasedSpecification(ref queryable, specification);


            return await queryable.ExecuteDeleteAsync();
        }
    }
}
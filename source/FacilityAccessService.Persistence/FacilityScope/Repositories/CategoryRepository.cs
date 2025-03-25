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

        public override async Task CreateAsync(Business.FacilityScope.Models.Category model)
        {
            Category category = _mapper.Map<Category>(model);

            await AlignCategoryFacilities(category);
            // Tell ef core not to touch nested facilities of category since
            // we have already performed the above operations with links ourselves
            if (category.Facilities is not null)
            {
                foreach (var facility in category.Facilities)
                {
                    _context.Entry(facility).State = EntityState.Unchanged;
                }
            }

            _context.Add(category);
        }

        public override async Task UpdateAsync(Business.FacilityScope.Models.Category model)
        {
            Category category = _mapper.Map<Category>(model);

            await AlignCategoryFacilities(category);
            _context.Update(category);

            // Tell ef core not to touch nested facilities of category since
            // we have already performed the above operations with links ourselves
            _context.Entry(category).Collection(x => x.Facilities).IsModified = false;
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

        /// <summary>
        /// Normalizes relationships based on the nested Facilities within a Category.
        /// </summary>
        private async Task AlignCategoryFacilities(Category category)
        {
            // Finds all relationships from a Category to its Facilities
            List<CategoryFacility> categoryFacilities = await _context.CategoryFacilities.Where(categoryFacility =>
                categoryFacility.CategoryId == category.Id
            ).ToListAsync();


            List<CategoryFacility> linksToDelete = categoryFacilities.ExceptBy(
                category.Facilities.Select(x => x.Id), x => x.FacilityId
            ).ToList();

            _context.RemoveRange(linksToDelete);


            List<Facility> facilitiesToLink = category.Facilities.ExceptBy(
                categoryFacilities.Select(x => x.FacilityId), x => x.Id
            ).ToList();

            List<CategoryFacility> linksToAdd = facilitiesToLink.Select(facilitiesToLink => new CategoryFacility()
            {
                CategoryId = category.Id,
                FacilityId = facilitiesToLink.Id
            }).ToList();

            _context.AddRange(linksToAdd);
        }
    }
}
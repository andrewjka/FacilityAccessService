using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FacilityAccessService.Business.AccessScope.Repositories;
using FacilityAccessService.Business.CommonScope.Specification;
using FacilityAccessService.Persistence.AccessScope.Models;
using FacilityAccessService.Persistence.CommonScope.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FacilityAccessService.Persistence.AccessScope.Repositories
{
    public class UserCategoryRepository : BaseRepository<UserCategory, Business.AccessScope.Models.UserCategory>,
        IUserCategoryRepository
    {
        public UserCategoryRepository(AppDatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<Business.AccessScope.Models.UserCategory> FirstByAsync(
            Specification<Business.AccessScope.Models.UserCategory> specification)
        {
            IQueryable<UserCategory> queryable = _context.UserCategories;

            BuildQueryBasedSpecification(ref queryable, specification);


            var userCategoryDb = await queryable.FirstOrDefaultAsync();

            return _mapper.Map<Business.AccessScope.Models.UserCategory>(userCategoryDb);
        }

        public override async Task<ReadOnlyCollection<Business.AccessScope.Models.UserCategory>> SelectByAsync(
            Specification<Business.AccessScope.Models.UserCategory> specification
        )
        {
            IQueryable<UserCategory> queryable = _context.UserCategories;

            BuildQueryBasedSpecification(ref queryable, specification);


            var userCategories = await queryable.ToListAsync();

            return _mapper.Map<List<Business.AccessScope.Models.UserCategory>>(userCategories).AsReadOnly();
        }

        public override async Task<int> DeleteByAsync(
            Specification<Business.AccessScope.Models.UserCategory> specification)
        {
            IQueryable<UserCategory> queryable = _context.UserCategories;

            BuildQueryBasedSpecification(ref queryable, specification);


            return await queryable.ExecuteDeleteAsync();
        }
    }
}
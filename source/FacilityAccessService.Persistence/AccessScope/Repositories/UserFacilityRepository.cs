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
    public class UserFacilityRepository : BaseRepository<UserFacility, Business.AccessScope.Models.UserFacility>,
        IUserFacilityRepository
    {
        public UserFacilityRepository(AppMySQLContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<Business.AccessScope.Models.UserFacility> FirstByAsync(
            Specification<Business.AccessScope.Models.UserFacility> specification)
        {
            IQueryable<UserFacility> queryable = _context.UserFacilities;

            BuildQueryBasedSpecification(ref queryable, specification);


            var userFacilityDb = await queryable.FirstOrDefaultAsync();

            return _mapper.Map<Business.AccessScope.Models.UserFacility>(userFacilityDb);
        }

        public override async Task<ReadOnlyCollection<Business.AccessScope.Models.UserFacility>> SelectByAsync(
            Specification<Business.AccessScope.Models.UserFacility> specification)
        {
            IQueryable<UserFacility> queryable = _context.UserFacilities;

            BuildQueryBasedSpecification(ref queryable, specification);


            var userFacilities = await queryable.ToListAsync();

            return _mapper.Map<List<Business.AccessScope.Models.UserFacility>>(userFacilities).AsReadOnly();
        }

        public override async Task<int> DeleteByAsync(
            Specification<Business.AccessScope.Models.UserFacility> specification)
        {
            IQueryable<UserFacility> queryable = _context.UserFacilities;

            BuildQueryBasedSpecification(ref queryable, specification);


            return await queryable.ExecuteDeleteAsync();
        }
    }
}
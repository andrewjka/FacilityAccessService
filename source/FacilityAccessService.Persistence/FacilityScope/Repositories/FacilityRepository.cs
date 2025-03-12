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
    public class FacilityRepository : BaseRepository<Facility, Business.FacilityScope.Models.Facility>,
        IFacilityRepository
    {
        public FacilityRepository(AppDatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<Business.FacilityScope.Models.Facility> FirstByAsync(
            Specification<Business.FacilityScope.Models.Facility> specification)
        {
            IQueryable<Facility> queryable = _context.Facilities;

            BuildQueryBasedSpecification(ref queryable, specification);


            var facilitydb = await queryable.FirstOrDefaultAsync();

            return _mapper.Map<Business.FacilityScope.Models.Facility>(facilitydb);
        }

        public override async Task<ReadOnlyCollection<Business.FacilityScope.Models.Facility>> SelectByAsync(
            Specification<Business.FacilityScope.Models.Facility> specification)
        {
            IQueryable<Facility> queryable = _context.Facilities;

            BuildQueryBasedSpecification(ref queryable, specification);


            var users = await queryable.ToListAsync();

            return _mapper.Map<List<Business.FacilityScope.Models.Facility>>(users).AsReadOnly();
        }

        public override async Task<int> DeleteByAsync(
            Specification<Business.FacilityScope.Models.Facility> specification)
        {
            IQueryable<Facility> queryable = _context.Facilities;

            BuildQueryBasedSpecification(ref queryable, specification);


            return await queryable.ExecuteDeleteAsync();
        }
    }
}
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.CommonScope.Specification;
using Domain.FacilityScope.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.CommonScope.Repositories;
using Persistence.FacilityScope.Models;

namespace Persistence.FacilityScope.Repositories;

public class FacilityRepository : BaseRepository<Facility, Domain.FacilityScope.Models.Facility>,
    IFacilityRepository
{
    public FacilityRepository(AppDatabaseContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public override async Task<Domain.FacilityScope.Models.Facility> FirstByAsync(
        Specification<Domain.FacilityScope.Models.Facility> specification)
    {
        IQueryable<Facility> queryable = _context.Facilities;

        BuildQueryBasedSpecification(ref queryable, specification);


        var facilitydb = await queryable.FirstOrDefaultAsync();

        return _mapper.Map<Domain.FacilityScope.Models.Facility>(facilitydb);
    }

    public override async Task<ReadOnlyCollection<Domain.FacilityScope.Models.Facility>> SelectByAsync(
        Specification<Domain.FacilityScope.Models.Facility> specification)
    {
        IQueryable<Facility> queryable = _context.Facilities;

        BuildQueryBasedSpecification(ref queryable, specification);


        var users = await queryable.ToListAsync();

        return _mapper.Map<List<Domain.FacilityScope.Models.Facility>>(users).AsReadOnly();
    }

    public override async Task<int> DeleteByAsync(
        Specification<Domain.FacilityScope.Models.Facility> specification)
    {
        IQueryable<Facility> queryable = _context.Facilities;

        BuildQueryBasedSpecification(ref queryable, specification);


        return await queryable.ExecuteDeleteAsync();
    }
}
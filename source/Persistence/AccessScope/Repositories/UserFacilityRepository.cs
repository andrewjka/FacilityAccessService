using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.AccessScope.Repositories;
using Domain.CommonScope.Specification;
using Microsoft.EntityFrameworkCore;
using Persistence.AccessScope.Models;
using Persistence.CommonScope.Repositories;

namespace Persistence.AccessScope.Repositories;

public class UserFacilityRepository : BaseRepository<UserFacility, Domain.AccessScope.Models.UserFacility>,
    IUserFacilityRepository
{
    public UserFacilityRepository(AppDatabaseContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public override async Task<Domain.AccessScope.Models.UserFacility> FirstByAsync(
        Specification<Domain.AccessScope.Models.UserFacility> specification)
    {
        IQueryable<UserFacility> queryable = _context.UserFacilities;

        BuildQueryBasedSpecification(ref queryable, specification);


        var userFacilityDb = await queryable.FirstOrDefaultAsync();

        return _mapper.Map<Domain.AccessScope.Models.UserFacility>(userFacilityDb);
    }

    public override async Task<ReadOnlyCollection<Domain.AccessScope.Models.UserFacility>> SelectByAsync(
        Specification<Domain.AccessScope.Models.UserFacility> specification)
    {
        IQueryable<UserFacility> queryable = _context.UserFacilities;

        BuildQueryBasedSpecification(ref queryable, specification);


        var userFacilities = await queryable.ToListAsync();

        return _mapper.Map<List<Domain.AccessScope.Models.UserFacility>>(userFacilities).AsReadOnly();
    }

    public override async Task<int> DeleteByAsync(
        Specification<Domain.AccessScope.Models.UserFacility> specification)
    {
        IQueryable<UserFacility> queryable = _context.UserFacilities;

        BuildQueryBasedSpecification(ref queryable, specification);


        return await queryable.ExecuteDeleteAsync();
    }
}
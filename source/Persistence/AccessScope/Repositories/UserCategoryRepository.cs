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

public class UserCategoryRepository : BaseRepository<UserCategory, Domain.AccessScope.Models.UserCategory>,
    IUserCategoryRepository
{
    public UserCategoryRepository(AppDatabaseContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public override async Task<Domain.AccessScope.Models.UserCategory> FirstByAsync(
        Specification<Domain.AccessScope.Models.UserCategory> specification)
    {
        IQueryable<UserCategory> queryable = _context.UserCategories;

        BuildQueryBasedSpecification(ref queryable, specification);


        var userCategoryDb = await queryable.FirstOrDefaultAsync();

        return _mapper.Map<Domain.AccessScope.Models.UserCategory>(userCategoryDb);
    }

    public override async Task<ReadOnlyCollection<Domain.AccessScope.Models.UserCategory>> SelectByAsync(
        Specification<Domain.AccessScope.Models.UserCategory> specification
    )
    {
        IQueryable<UserCategory> queryable = _context.UserCategories;

        BuildQueryBasedSpecification(ref queryable, specification);


        var userCategories = await queryable.ToListAsync();

        return _mapper.Map<List<Domain.AccessScope.Models.UserCategory>>(userCategories).AsReadOnly();
    }

    public override async Task<int> DeleteByAsync(
        Specification<Domain.AccessScope.Models.UserCategory> specification)
    {
        IQueryable<UserCategory> queryable = _context.UserCategories;

        BuildQueryBasedSpecification(ref queryable, specification);


        return await queryable.ExecuteDeleteAsync();
    }
}
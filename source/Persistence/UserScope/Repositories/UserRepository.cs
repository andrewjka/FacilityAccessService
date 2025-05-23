using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.CommonScope.Specification;
using Domain.UserScope.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.CommonScope.Repositories;
using Persistence.UserScope.Models;

namespace Persistence.UserScope.Repositories;

public class UserRepository : BaseRepository<User, Domain.UserScope.Models.User>, IUserRepository
{
    public UserRepository(AppDatabaseContext context, IMapper mapper) : base(context, mapper)
    {
    }


    public override async Task<Domain.UserScope.Models.User> FirstByAsync(
        Specification<Domain.UserScope.Models.User> specification)
    {
        IQueryable<User> queryable = _context.Users;

        BuildQueryBasedSpecification(ref queryable, specification);


        var userdb = await queryable.FirstOrDefaultAsync();

        return _mapper.Map<Domain.UserScope.Models.User>(userdb);
    }

    public override async Task<ReadOnlyCollection<Domain.UserScope.Models.User>> SelectByAsync(
        Specification<Domain.UserScope.Models.User> specification)
    {
        IQueryable<User> queryable = _context.Users;

        BuildQueryBasedSpecification(ref queryable, specification);


        var users = await queryable.ToListAsync();

        return _mapper.Map<List<Domain.UserScope.Models.User>>(users).AsReadOnly();
    }

    public override async Task<int> DeleteByAsync(Specification<Domain.UserScope.Models.User> specification)
    {
        IQueryable<User> queryable = _context.Users;

        BuildQueryBasedSpecification(ref queryable, specification);


        return await queryable.ExecuteDeleteAsync();
    }
}
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FacilityAccessService.Business.CommonScope.Specification;
using FacilityAccessService.Business.UserScope.Repositories;
using FacilityAccessService.Persistence.CommonScope.Repositories;
using FacilityAccessService.Persistence.UserScope.Models;
using Microsoft.EntityFrameworkCore;

namespace FacilityAccessService.Persistence.UserScope.Repositories
{
    public class UserRepository : BaseRepository<User, Business.UserScope.Models.User>, IUserRepository
    {
        public UserRepository(AppDatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }


        public override async Task<Business.UserScope.Models.User> FirstByAsync(
            Specification<Business.UserScope.Models.User> specification)
        {
            IQueryable<User> queryable = _context.Users;

            BuildQueryBasedSpecification(ref queryable, specification);


            var userdb = await queryable.FirstOrDefaultAsync();

            return _mapper.Map<Business.UserScope.Models.User>(userdb);
        }

        public override async Task<ReadOnlyCollection<Business.UserScope.Models.User>> SelectByAsync(
            Specification<Business.UserScope.Models.User> specification)
        {
            IQueryable<User> queryable = _context.Users;

            BuildQueryBasedSpecification(ref queryable, specification);


            var users = await queryable.ToListAsync();

            return _mapper.Map<List<Business.UserScope.Models.User>>(users).AsReadOnly();
        }

        public override async Task<int> DeleteByAsync(Specification<Business.UserScope.Models.User> specification)
        {
            IQueryable<User> queryable = _context.Users;

            BuildQueryBasedSpecification(ref queryable, specification);


            return await queryable.ExecuteDeleteAsync();
        }
    }
}
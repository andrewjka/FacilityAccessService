using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FacilityAccessService.Business.CommonScope.Specification;
using FacilityAccessService.Business.TerminalScope.Repositories;
using FacilityAccessService.Persistence.CommonScope.Repositories;
using FacilityAccessService.Persistence.TerminalScope.Models;
using Microsoft.EntityFrameworkCore;

namespace FacilityAccessService.Persistence.TerminalScope.Repositories
{
    public class TerminalRepository : BaseRepository<Terminal, Business.TerminalScope.Models.Terminal>,
        ITerminalRepository
    {
        public TerminalRepository(AppMySQLContext context, IMapper mapper) : base(context, mapper)
        {
        }


        public override async Task<Business.TerminalScope.Models.Terminal> FirstByAsync(
            Specification<Business.TerminalScope.Models.Terminal> specification)
        {
            IQueryable<Terminal> queryable = _context.Terminals;

            BuildQueryBasedSpecification(ref queryable, specification);


            var terminaldb = await queryable.FirstOrDefaultAsync();

            return _mapper.Map<Business.TerminalScope.Models.Terminal>(terminaldb);
        }

        public override async Task<ReadOnlyCollection<Business.TerminalScope.Models.Terminal>> SelectByAsync(
            Specification<Business.TerminalScope.Models.Terminal> specification)
        {
            IQueryable<Terminal> queryable = _context.Terminals;

            BuildQueryBasedSpecification(ref queryable, specification);


            var users = await queryable.ToListAsync();

            return _mapper.Map<List<Business.TerminalScope.Models.Terminal>>(users).AsReadOnly();
        }

        public override async Task<int> DeleteByAsync(
            Specification<Business.TerminalScope.Models.Terminal> specification)
        {
            IQueryable<Terminal> queryable = _context.Terminals;

            BuildQueryBasedSpecification(ref queryable, specification);


            return await queryable.ExecuteDeleteAsync();
        }
    }
}
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.CommonScope.Specification;
using Domain.TerminalScope.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.CommonScope.Repositories;
using Persistence.TerminalScope.Models;

namespace Persistence.TerminalScope.Repositories;

public class TerminalRepository : BaseRepository<Terminal, Domain.TerminalScope.Models.Terminal>,
    ITerminalRepository
{
    public TerminalRepository(AppDatabaseContext context, IMapper mapper) : base(context, mapper)
    {
    }


    public override async Task<Domain.TerminalScope.Models.Terminal> FirstByAsync(
        Specification<Domain.TerminalScope.Models.Terminal> specification)
    {
        IQueryable<Terminal> queryable = _context.Terminals;

        BuildQueryBasedSpecification(ref queryable, specification);


        var terminaldb = await queryable.FirstOrDefaultAsync();

        return _mapper.Map<Domain.TerminalScope.Models.Terminal>(terminaldb);
    }

    public override async Task<ReadOnlyCollection<Domain.TerminalScope.Models.Terminal>> SelectByAsync(
        Specification<Domain.TerminalScope.Models.Terminal> specification)
    {
        IQueryable<Terminal> queryable = _context.Terminals;

        BuildQueryBasedSpecification(ref queryable, specification);


        var users = await queryable.ToListAsync();

        return _mapper.Map<List<Domain.TerminalScope.Models.Terminal>>(users).AsReadOnly();
    }

    public override async Task<int> DeleteByAsync(
        Specification<Domain.TerminalScope.Models.Terminal> specification)
    {
        IQueryable<Terminal> queryable = _context.Terminals;

        BuildQueryBasedSpecification(ref queryable, specification);


        return await queryable.ExecuteDeleteAsync();
    }
}
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.AuthScope.Models;
using Domain.AuthScope.Repositories;
using Domain.CommonScope.Specification;
using Microsoft.EntityFrameworkCore;
using Persistence.CommonScope.Repositories;

namespace Persistence.AuthScope.Repositories;

public class RefreshTokenRepository : BaseRepository<Models.RefreshToken, Domain.AuthScope.Models.RefreshToken>,
    IRefreshTokenRepository
{
    public RefreshTokenRepository(AppDatabaseContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public override async Task<RefreshToken> FirstByAsync(Specification<RefreshToken> specification)
    {
        IQueryable<Models.RefreshToken> queryable = _context.RefreshTokens;

        BuildQueryBasedSpecification(ref queryable, specification);


        var refreshToken = await queryable.FirstOrDefaultAsync();

        return _mapper.Map<Domain.AuthScope.Models.RefreshToken>(refreshToken);
    }

    public override async Task<ReadOnlyCollection<RefreshToken>> SelectByAsync(
        Specification<RefreshToken> specification)
    {
        IQueryable<Models.RefreshToken> queryable = _context.RefreshTokens;

        BuildQueryBasedSpecification(ref queryable, specification);


        var refreshTokens = await queryable.ToListAsync();

        return _mapper.Map<List<Domain.AuthScope.Models.RefreshToken>>(refreshTokens).AsReadOnly();
    }

    public override async Task<int> DeleteByAsync(Specification<RefreshToken> specification)
    {
        IQueryable<Models.RefreshToken> queryable = _context.RefreshTokens;

        BuildQueryBasedSpecification(ref queryable, specification);


        return await queryable.ExecuteDeleteAsync();
    }
}
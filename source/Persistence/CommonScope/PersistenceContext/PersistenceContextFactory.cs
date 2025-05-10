using System.Threading.Tasks;
using AutoMapper;
using Domain.CommonScope.PersistenceContext;

namespace Persistence.CommonScope.PersistenceContext;

public class PersistenceContextFactory : IPersistenceContextFactory
{
    private readonly AppDatabaseContext _databaseContext;

    private readonly IMapper _mapper;


    public PersistenceContextFactory(AppDatabaseContext databaseContext, IMapper mapper)
    {
        _databaseContext = databaseContext;
        _mapper = mapper;
    }


    public async Task<IPersistenceContext> CreatePersistenceContextAsync()
    {
        var persistenceContext = new PersistenceContext(
            _databaseContext,
            await _databaseContext.Database.BeginTransactionAsync(),
            _mapper
        );

        return persistenceContext;
    }
}
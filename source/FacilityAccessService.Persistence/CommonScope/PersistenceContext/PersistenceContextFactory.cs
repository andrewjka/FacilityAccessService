using System.Threading.Tasks;
using AutoMapper;
using FacilityAccessService.Business.CommonScope.PersistenceContext;

namespace FacilityAccessService.Persistence.CommonScope.PersistenceContext
{
    public class PersistenceContextFactory : IPersistenceContextFactory
    {
        private readonly AppDatabaseContext _databaseContext;

        private readonly IMapper _mapper;


        public PersistenceContextFactory(AppDatabaseContext databaseContext, IMapper mapper)
        {
            this._databaseContext = databaseContext;
            this._mapper = mapper;
        }


        public async Task<IPersistenceContext> CreatePersistenceContextAsync()
        {
            PersistenceContext persistenceContext = new PersistenceContext(
                context: _databaseContext,
                transaction: await _databaseContext.Database.BeginTransactionAsync(),
                mapper: _mapper
            );

            return persistenceContext;
        }
    }
}
using System.Threading.Tasks;

namespace FacilityAccessService.Business.CommonScope.PersistenceContext
{
    public interface IPersistenceContextFactory
    {
        public Task<IPersistenceContext> CreatePersistenceContext();
    }
}
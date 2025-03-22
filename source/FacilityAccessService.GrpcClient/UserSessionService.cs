using FacilityAccessService.Business.CommonScope.PersistenceContext;
using FacilityAccessService.Business.CommonScope.Services;
using FacilityAccessService.Business.UserScope.Models;
using FacilityAccessService.Business.UserScope.Specifications;

namespace FacilityAccessService.GrpcClient
{
    public class UserSessionService : IUserSessionService
    {
        private readonly IPersistenceContextFactory _persistenceContextFactory;

        public UserSessionService(IPersistenceContextFactory persistenceContextFactory)
        {
            this._persistenceContextFactory = persistenceContextFactory;
        }

        public async Task<User> ValidateTokenAsync(string token)
        {
            FindByIdSpecification findByIdSpec = new FindByIdSpecification(token);

            User user;
            await using (IPersistenceContext context = await _persistenceContextFactory.CreatePersistenceContextAsync())
            {
                user = await context.UserRepository.FirstByAsync(findByIdSpec);
            }

            return user;
        }
    }
}
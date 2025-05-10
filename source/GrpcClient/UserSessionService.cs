using Domain.CommonScope.PersistenceContext;
using Domain.CommonScope.Services;
using Domain.UserScope.Models;
using Domain.UserScope.Specifications;

namespace GrpcClient;

public class UserSessionService : IUserSessionService
{
    private readonly IPersistenceContextFactory _persistenceContextFactory;

    public UserSessionService(IPersistenceContextFactory persistenceContextFactory)
    {
        _persistenceContextFactory = persistenceContextFactory;
    }

    public async Task<User> ValidateTokenAsync(string token)
    {
        var findByIdSpec = new FindByIdSpecification(token);

        User user;
        await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
        {
            user = await context.UserRepository.FirstByAsync(findByIdSpec);
        }

        return user;
    }
}
#region

using System;
using System.Threading.Tasks;
using Domain.AccessScope.Services;
using Domain.AccessScope.Specifications;
using Domain.CommonScope.PersistenceContext;

#endregion

namespace Business.AccessScope.Services;

public class CleanerExpiredAccessService : ICleanerExpiredAccessService
{
    private const int takeEntries = 500;
    private readonly IPersistenceContextFactory _persistenceContextFactory;


    public CleanerExpiredAccessService(IPersistenceContextFactory persistenceContextFactory)
    {
        if (persistenceContextFactory is null) throw new ArgumentNullException(nameof(persistenceContextFactory));

        _persistenceContextFactory = persistenceContextFactory;
    }

    public async Task ClearExpiredAccessAsync()
    {
        var expiredCategorySpec = new ExpiredAccessCategorySpecification(
            takeEntries
        );

        while (true)
        {
            var deletedCount = -1;
            await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
            {
                deletedCount = await context.UserCategoryRepository.DeleteByAsync(expiredCategorySpec);

                await context.ApplyChangesAsync();
                await context.CommitAsync();
            }

            if (deletedCount <= 0) break;
        }


        var expiredFacilitySpec = new ExpiredAccessFacilitySpecification(
            takeEntries
        );

        while (true)
        {
            var deletedCount = -1;
            await using (var context = await _persistenceContextFactory.CreatePersistenceContextAsync())
            {
                deletedCount = await context.UserFacilityRepository.DeleteByAsync(expiredFacilitySpec);

                await context.ApplyChangesAsync();
                await context.CommitAsync();
            }

            if (deletedCount <= 0) break;
        }
    }
}
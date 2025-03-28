#region

using System;
using System.Threading.Tasks;
using FacilityAccessService.Business.AccessScope.Services;
using FacilityAccessService.Business.AccessScope.Specifications;
using FacilityAccessService.Business.CommonScope.PersistenceContext;

#endregion

namespace FacilityAccessService.Domain.AccessScope.Services
{
    public class CleanerExpiredAccessService : ICleanerExpiredAccessService
    {
        private readonly IPersistenceContextFactory _persistenceContextFactory;

        private const int takeEntries = 500;


        public CleanerExpiredAccessService(IPersistenceContextFactory persistenceContextFactory)
        {
            if (persistenceContextFactory is null) throw new ArgumentNullException(nameof(persistenceContextFactory));

            this._persistenceContextFactory = persistenceContextFactory;
        }

        public async Task ClearExpiredAccessAsync()
        {
            ExpiredAccessCategorySpecification expiredCategorySpec = new ExpiredAccessCategorySpecification(
                take: takeEntries
            );

            while (true)
            {
                int deletedCount = -1;
                await using (IPersistenceContext context = await _persistenceContextFactory.CreatePersistenceContextAsync())
                {
                    deletedCount = await context.UserCategoryRepository.DeleteByAsync(expiredCategorySpec);
                    
                    await context.ApplyChangesAsync();
                    await context.CommitAsync();
                }

                if (deletedCount <= 0)
                {
                    break;
                }
            }


            ExpiredAccessFacilitySpecification expiredFacilitySpec = new ExpiredAccessFacilitySpecification(
                take: takeEntries
            );

            while (true)
            {
                int deletedCount = -1;
                await using (IPersistenceContext context = await _persistenceContextFactory.CreatePersistenceContextAsync())
                {
                    deletedCount = await context.UserFacilityRepository.DeleteByAsync(expiredFacilitySpec);
                    
                    await context.ApplyChangesAsync();
                    await context.CommitAsync();
                }

                if (deletedCount <= 0)
                {
                    break;
                }
            }
        }
    }
}
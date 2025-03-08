using System;
using System.Threading.Tasks;
using FacilityAccessService.Business.AccessScope.Services;
using FacilityAccessService.Business.AccessScope.Specifications;
using FacilityAccessService.Business.CommonScope.PersistenceContext;


namespace FacilityAccessService.Domain.AccessScope
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
                await using (IPersistenceContext context = await _persistenceContextFactory.CreatePersistenceContext())
                {
                    deletedCount = await context.UserCategoryRepository.DeleteByAsync(expiredCategorySpec);
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
                await using (IPersistenceContext context = await _persistenceContextFactory.CreatePersistenceContext())
                {
                    deletedCount = await context.UserFacilityRepository.DeleteByAsync(expiredFacilitySpec);
                }

                if (deletedCount <= 0)
                {
                    break;
                }
            }
        }
    }
}
using System;
using System.Threading.Tasks;
using FacilityAccessService.Business.AccessScope.Repositories;
using FacilityAccessService.Business.AccessScope.Services;
using FacilityAccessService.Business.AccessScope.Specifications;


namespace FacilityAccessService.Domain.AccessScope
{
    public class CleanerExpiredAccessService : ICleanerExpiredAccessService
    {
        private IUserCategoryRepository _userCategoryRepository;
        private IUserFacilityRepository _userFacilityRepository;

        private const int takeEntries = 500;


        public CleanerExpiredAccessService(
            IUserCategoryRepository userCategoryRepository,
            IUserFacilityRepository userFacilityRepository
        )
        {
            if (userCategoryRepository is null) throw new ArgumentNullException(nameof(userCategoryRepository));
            if (userFacilityRepository is null) throw new ArgumentNullException(nameof(userFacilityRepository));
            
            this._userCategoryRepository = userCategoryRepository;
            this._userFacilityRepository = userFacilityRepository;
        }

        public async Task ClearExpiredAccessAsync()
        {
            ExpiredAccessCategorySpecification expiredCategorySpec = new ExpiredAccessCategorySpecification(
                take: takeEntries
            );

            while (true)
            {
                int deletedCount = await _userCategoryRepository.DeleteByAsync(expiredCategorySpec);

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
                int deletedCount = await _userFacilityRepository.DeleteByAsync(expiredFacilitySpec);

                if (deletedCount <= 0)
                {
                    break;
                }
            }
        }
    }
}
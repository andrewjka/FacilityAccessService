using FacilityAccessService.Business.AccessScope.Repositories;
using FacilityAccessService.Business.FacilityScope.Repositories;
using FacilityAccessService.Business.TerminalScope.Repositories;
using FacilityAccessService.Business.UserScope.Repositories;

namespace FacilityAccessService.Business.CommonScope.PersistenceContext
{
    /// <summary>
    /// Implemented the unit of work pattern. Describes access to all repositories in a single collaboration.
    /// </summary>
    public interface IUnitWork
    {
        public IUserRepository UserRepository { get; }

        public ITerminalRepository TerminalRepository { get; }

        public IFacilityRepository FacilityRepository { get; }
        public ICategoryRepository CategoryRepository { get; }

        public IUserFacilityRepository UserFacilityRepository { get; }
        public IUserCategoryRepository UserCategoryRepository { get; }
    }
}
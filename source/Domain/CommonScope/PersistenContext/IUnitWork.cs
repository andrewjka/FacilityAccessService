#region

using Domain.AccessScope.Repositories;
using Domain.AuthScope.Repositories;
using Domain.FacilityScope.Repositories;
using Domain.TerminalScope.Repositories;
using Domain.UserScope.Repositories;

#endregion

namespace Domain.CommonScope.PersistenceContext;

/// <summary>
///     Implemented the unit of work pattern. Describes access to all repositories in a single collaboration.
/// </summary>
public interface IUnitWork
{
    public IUserRepository UserRepository { get; }

    public ITerminalRepository TerminalRepository { get; }

    public IFacilityRepository FacilityRepository { get; }
    public ICategoryRepository CategoryRepository { get; }

    public IUserFacilityRepository UserFacilityRepository { get; }
    public IUserCategoryRepository UserCategoryRepository { get; }

    public IRefreshTokenRepository RefreshTokenRepository { get; }
}
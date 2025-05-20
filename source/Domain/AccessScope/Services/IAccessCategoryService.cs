#region

using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Domain.AccessScope.Actions;
using Domain.AccessScope.Models;
using Domain.AccessScope.Services.Generic;
using Domain.AccessScope.ValueObjects;
using Domain.CommonScope.Specification;
using Domain.FacilityScope.Models;
using Domain.UserScope.Models;

#endregion

namespace Domain.AccessScope.Services;

/// <inheritdoc />
public interface IAccessCategoryService
    : IAccessService<GrantAccessCategoryModel, RevokeAccessCategoryModel, UpdateAccessCategoryModel>
{
    /// <summary>
    ///     Get the access User to Category by specification.
    /// </summary>
    public Task<UserCategoryDto> GetAccessAsync(
        Specification<UserCategory> specification
    );

    /// <summary>
    ///     Get all access User to Category by specification.
    /// </summary>
    public Task<ReadOnlyCollection<UserCategoryDto>> GetAccessesAsync(
        Specification<UserCategory> specification
    );
}

public record UserCategoryDto(User User, Category Category, AccessPeriod AccessPeriod);
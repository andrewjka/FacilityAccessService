#region

using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Domain.AccessScope.Actions;
using Domain.AccessScope.Models;
using Domain.AccessScope.Services.Generic;
using Domain.CommonScope.Specification;

#endregion

namespace Domain.AccessScope.Services;

/// <inheritdoc />
public interface IAccessCategoryService
    : IAccessService<GrantAccessCategoryModel, RevokeAccessCategoryModel, UpdateAccessCategoryModel>
{
    /// <summary>
    ///     Get the access User to Category by specification.
    /// </summary>
    public Task<UserCategory> GetAccessAsync(
        Specification<UserCategory> specification
    );

    /// <summary>
    ///     Get all access User to Category by specification.
    /// </summary>
    public Task<ReadOnlyCollection<UserCategory>> GetAccessesAsync(
        Specification<UserCategory> specification
    );
}
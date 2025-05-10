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
public interface IAccessFacilityService
    : IAccessService<GrantAccessFacilityModel, RevokeAccessFacilityModel, UpdateAccessFacilityModel>
{
    /// <summary>
    ///     Get the access User to Facility by specification.
    /// </summary>
    public Task<UserFacility> GetAccessAsync(
        Specification<UserFacility> specification
    );

    /// <summary>
    ///     Get all access User to Facility by specification.
    /// </summary>
    public Task<ReadOnlyCollection<UserFacility>> GetAccessesAsync(
        Specification<UserFacility> specification
    );
}
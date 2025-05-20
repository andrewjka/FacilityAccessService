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
public interface IAccessFacilityService
    : IAccessService<GrantAccessFacilityModel, RevokeAccessFacilityModel, UpdateAccessFacilityModel>
{
    /// <summary>
    ///     Get the access User to Facility by specification.
    /// </summary>
    public Task<UserFacilityDto> GetAccessAsync(
        Specification<UserFacility> specification
    );

    /// <summary>
    ///     Get all access User to Facility by specification.
    /// </summary>
    public Task<ReadOnlyCollection<UserFacilityDto>> GetAccessesAsync(
        Specification<UserFacility> specification
    );
}

public record UserFacilityDto(User User, Facility Facility, AccessPeriod AccessPeriod);
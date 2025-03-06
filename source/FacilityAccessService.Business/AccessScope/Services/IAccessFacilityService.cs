using FacilityAccessService.Business.AccessScope.Actions;
using FacilityAccessService.Business.AccessScope.Services.Generic;

namespace FacilityAccessService.Business.AccessScope.Services
{
    /// <inheritdoc/>
    public interface IAccessFacilityService
        : IAccessService<GrantAccessFacilityModel, RevokeAccessFacilityModel, UpdateAccessFacilityModel>
    {
    }
}
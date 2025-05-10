#region

using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Business.Secure.CommonScope.Abstractions;
using Business.Secure.CommonScope.Context;
using Business.Secure.FacilityScope.Interfaces;
using Domain.CommonScope.Specification;
using Domain.FacilityScope.Actions;
using Domain.FacilityScope.Models;
using Domain.FacilityScope.Services;
using Domain.UserScope.ValueObjects;

#endregion

namespace Business.Secure.FacilityScope;

public class FacilityServiceSecure : BaseUserAuthorization, IFacilityServiceSecure
{
    private readonly IFacilityService _facilityService;


    public FacilityServiceSecure(IFacilityService facilityService, IUserContext userContext) : base(userContext)
    {
        if (facilityService is null) throw new ArgumentNullException(nameof(facilityService));

        _facilityService = facilityService;
    }


    public async Task<Facility> CreateFacilityAsync(CreateFacilityModel createFacilityModel)
    {
        return await _facilityService.CreateFacilityAsync(createFacilityModel);
    }

    public async Task<Facility> GetFacilityAsync(Specification<Facility> specification)
    {
        return await _facilityService.GetFacilityAsync(specification);
    }

    public async Task<ReadOnlyCollection<Facility>> GetFacilitiesAsync(Specification<Facility> specification)
    {
        return await _facilityService.GetFacilitiesAsync(specification);
    }

    public async Task<Facility> UpdateFacilityAsync(UpdateFacilityModel updateFacilityModel)
    {
        return await _facilityService.UpdateFacilityAsync(updateFacilityModel);
    }

    public async Task DeleteFacilityAsync(DeleteFacilityModel deleteFacilityModel)
    {
        await _facilityService.DeleteFacilityAsync(deleteFacilityModel);
    }

    protected override void EnsureHasPermission()
    {
        var hasAccess = _userContext.User.Role.CheckPermission(Permission.CanMaintenanceFacility);
        if (hasAccess is false)
            throw new UnauthorizedAccessException(
                "The current user does not have permission to maintain facilities."
            );
    }
}
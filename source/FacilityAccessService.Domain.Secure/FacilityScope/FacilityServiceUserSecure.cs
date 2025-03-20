using System;
using System.Threading.Tasks;
using FacilityAccessService.Business.FacilityScope.Actions;
using FacilityAccessService.Business.FacilityScope.Models;
using FacilityAccessService.Business.FacilityScope.Services;
using FacilityAccessService.Business.UserScope.ValueObjects;
using FacilityAccessService.Domain.Secure.CommonScope.Abstractions;
using FacilityAccessService.Domain.Secure.CommonScope.Context;
using FacilityAccessService.Domain.Secure.FacilityScope.Interfaces;

namespace FacilityAccessService.Domain.Secure.FacilityScope
{
    public class FacilityServiceUserSecure : BaseServiceUserSecure, IFacilityServiceSecure
    {
        private readonly IFacilityService _facilityService;
        
        
        public FacilityServiceUserSecure(IFacilityService facilityService, IUserContext userContext) : base(userContext)
        {
            if (facilityService is null) throw new ArgumentNullException(nameof(facilityService));

            this._facilityService = facilityService;
        }

        
        public async Task<Facility> CreateFacilityAsync(CreateFacilityModel createFacilityModel)
        {
            return await _facilityService.CreateFacilityAsync(createFacilityModel);
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
            bool hasAccess = _userContext.User.Role.CheckPermission(Permission.CanMaintenanceFacility);
            if (hasAccess is false)
            {
                throw new UnauthorizedAccessException(
                    "The current user does not have permission to maintain facilities."
                );
            }
        }
    }
}
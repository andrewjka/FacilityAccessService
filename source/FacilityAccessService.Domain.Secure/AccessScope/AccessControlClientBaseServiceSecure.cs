using System;
using System.Threading.Tasks;
using FacilityAccessService.Business.AccessScope.Actions;
using FacilityAccessService.Business.AccessScope.Services;
using FacilityAccessService.Business.UserScope.ValueObjects;
using FacilityAccessService.Domain.Secure.AccessScope.Interfaces;
using FacilityAccessService.Domain.Secure.CommonScope.Abstractions;
using FacilityAccessService.Domain.Secure.CommonScope.Context;

namespace FacilityAccessService.Domain.Secure.AccessScope
{
    public class AccessControlClientBaseServiceSecure : BaseServiceSecure, IAccessControlClientServiceSecure
    {
        private readonly IAccessControlClientService _accessControl;


        public AccessControlClientBaseServiceSecure(
            IAccessControlClientService accessControl,
            IUserContext userContext
        ) : base(userContext)
        {
            if (accessControl is null) throw new ArgumentNullException(nameof(accessControl));

            this._accessControl = accessControl;
        }

        
        public async Task<bool> VerifyAccessAsync(VerifyAccessViaGuardModel verifyAccessModel)
        {
            return await _accessControl.VerifyAccessAsync(verifyAccessModel);
        }

        protected override void EnsureHasPermission()
        {
            bool hasAccess = _userContext.User.Role.CheckPermission(Permission.CanCheckPass);
            if (hasAccess is false)
            {
                throw new UnauthorizedAccessException(
                    "The current user does not have permission to check user access to facility."
                );
            }
        }
    }
}
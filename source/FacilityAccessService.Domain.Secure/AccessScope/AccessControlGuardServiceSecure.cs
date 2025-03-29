#region

using System;
using System.Threading.Tasks;
using FacilityAccessService.Business.AccessScope.Actions.Abstractions;
using FacilityAccessService.Business.AccessScope.Services;
using FacilityAccessService.Business.UserScope.ValueObjects;
using FacilityAccessService.Domain.Secure.AccessScope.Interfaces;
using FacilityAccessService.Domain.Secure.CommonScope.Abstractions;
using FacilityAccessService.Domain.Secure.CommonScope.Context;

#endregion

namespace FacilityAccessService.Domain.Secure.AccessScope
{
    public class AccessControlGuardServiceSecure : BaseUserAuthorization, IAccessControlGuardServiceSecure
    {
        private readonly IAccessControlService _accessControl;


        public AccessControlGuardServiceSecure(
            IAccessControlService accessControl,
            IUserContext userContext
        ) : base(userContext)
        {
            if (accessControl is null) throw new ArgumentNullException(nameof(accessControl));

            this._accessControl = accessControl;
        }


        public async Task<bool> VerifyAccessAsync(VerifyAccessModel verifyAccessModel)
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
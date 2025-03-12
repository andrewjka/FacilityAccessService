using System;
using System.Threading.Tasks;
using FacilityAccessService.Business.AccessScope.Actions;
using FacilityAccessService.Business.AccessScope.Services;
using FacilityAccessService.Domain.Secure.AccessScope.Interfaces;

namespace FacilityAccessService.Domain.Secure.AccessScope
{
    public class AccessControlTerminalServiceSecure : IAccessControlTerminalServiceSecure
    {
        private readonly IAccessControlTerminalService _accessControl;


        public AccessControlTerminalServiceSecure(IAccessControlTerminalService accessControl)
        {
            if (accessControl is null) throw new ArgumentNullException(nameof(accessControl));
            
            this._accessControl = accessControl;
        }

        public async Task<bool> VerifyAccessAsync(VerifyAccessViaTerminalModel verifyAccessModel)
        {
            return await _accessControl.VerifyAccessAsync(verifyAccessModel);
        }
    }
}
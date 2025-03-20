#region

using System;
using System.Threading.Tasks;
using FacilityAccessService.Business.AccessScope.Actions.Abstractions;
using FacilityAccessService.Business.AccessScope.Services;
using FacilityAccessService.Domain.Secure.AccessScope.Interfaces;
using FacilityAccessService.Domain.Secure.CommonScope.Abstractions;
using FacilityAccessService.Domain.Secure.CommonScope.Context;

#endregion

namespace FacilityAccessService.Domain.Secure.AccessScope
{
    public class AccessControlTerminalServiceSecure : BaseServiceTerminalSecure, IAccessControlTerminalServiceSecure
    {
        private readonly IAccessControlService _accessControl;


        public AccessControlTerminalServiceSecure(
            IAccessControlService accessControl,
            ITerminalContext terminalContext
        ) : base(terminalContext)
        {
            if (accessControl is null) throw new ArgumentNullException(nameof(accessControl));

            this._accessControl = accessControl;
        }


        public async Task<bool> VerifyAccessAsync(VerifyAccessModel verifyAccessModel)
        {
            return await _accessControl.VerifyAccessAsync(verifyAccessModel);
        }
    }
}
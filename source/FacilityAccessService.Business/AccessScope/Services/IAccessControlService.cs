#region

using System.Threading.Tasks;
using FacilityAccessService.Business.AccessScope.Actions.Abstractions;

#endregion

namespace FacilityAccessService.Business.AccessScope.Services
{
    /// <summary>
    /// Describes a service for verify User access to Facility.
    /// </summary>
    public interface IAccessControlService
    {
        /// <summary>
        /// Verifying access via specific access checker.
        /// </summary>
        public Task<bool> VerifyAccessAsync(VerifyAccessModel verifyAccessModel);
    }
}
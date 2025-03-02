using System.Threading.Tasks;
using FacilityAccessService.Business.Access.Actions;
using FacilityAccessService.Business.Access.Actions.Generic;

namespace FacilityAccessService.Business.Access.Services.Generic
{
    /// <summary>
    /// Describes a service for verify access via specific access checker.
    /// </summary>
    /// <typeparam name="TAccessChecker">The model through which access verification is performed</typeparam>
    public interface IAccessControlService<TAccessChecker> where TAccessChecker : class
    {
        /// <summary>
        /// Verifying access via specific access checker.
        /// </summary>
        /// <param name="verifyAccessModel"></param>
        /// <returns></returns>
        public Task<bool> VerifyAccessAsync(VerifyAccessModel<TAccessChecker> verifyAccessModel);
    }
}
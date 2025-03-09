using System.Threading.Tasks;
using FacilityAccessService.Business.AccessScope.Actions.Abstractions;

namespace FacilityAccessService.Business.AccessScope.Services.Generic
{
    /// <summary>
    /// Describes a service for verify access via specific access model.
    /// </summary>
    /// <typeparam name="TAccessVerifyModel">The model through which access verification is performed.</typeparam>
    public interface IAccessControlService<TAccessVerifyModel> where TAccessVerifyModel : VerifyAccessModel
    {
        /// <summary>
        /// Verifying access via specific access checker.
        /// </summary>
        public Task<bool> VerifyAccessAsync(TAccessVerifyModel verifyAccessModel);
    }
}
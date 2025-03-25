#region

using System.Threading.Tasks;
using FacilityAccessService.Business.AccessScope.Actions.Abstractions;

#endregion

namespace FacilityAccessService.Business.AccessScope.Services.Generic
{
    /// <summary>
    /// Describes the service to management User access to specific accessed model.
    /// </summary>
    public interface IAccessService<TGrantAccessModel, TRevokeAccessModel, TUpdateAccessModel>
        where TGrantAccessModel : GrantAccessModel
        where TRevokeAccessModel : RevokeAccessModel
        where TUpdateAccessModel : UpdateAccessModel
    {
        /// <summary>
        /// Gives the User access to a specific accessed model.
        /// </summary>
        public Task GrantAccessAsync(TGrantAccessModel grantAccessModel);

        /// <summary>
        /// Revoke the User access to a specific accessed model.
        /// </summary>
        public Task RevokeAccessAsync(TRevokeAccessModel revokeAccessModel);

        /// <summary>
        /// Updates the user access to a specific accessed model.
        /// </summary>
        public Task UpdateAccessAsync(TUpdateAccessModel updateAccessModel);
    }
}
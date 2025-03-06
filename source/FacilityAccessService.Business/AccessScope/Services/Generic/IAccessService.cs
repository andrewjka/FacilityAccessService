using System.Threading.Tasks;
using FacilityAccessService.Business.AccessScope.Actions.Abstractions;
using FacilityAccessService.Business.FacilityScope.Models;

namespace FacilityAccessService.Business.AccessScope.Services.Generic
{
    /// <summary>
    /// Describes the service to management user access to specific accessed model.
    /// </summary>
    public interface IAccessService<TGrantAccessModel, TRevokeAccessModel, TUpdateAccessModel>
        where TGrantAccessModel : GrantAccessModel
        where TRevokeAccessModel : RevokeAccessModel
        where TUpdateAccessModel : UpdateAccessModel
    {
        public Task GrantAccessAsync(TGrantAccessModel grantAccessModel);

        public Task RevokeAccessAsync(TRevokeAccessModel revokeAccessModel);

        public Task UpdateAccessAsync(TUpdateAccessModel updateAccessModel);
    }
}
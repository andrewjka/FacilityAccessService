using System.Threading.Tasks;
using FacilityAccessService.Business.Access.Actions.Generic;

namespace FacilityAccessService.Business.Access.Services.Generic
{
    /// <summary>
    /// Describes the service for the main cases with the specific access model.
    /// </summary>
    /// <typeparam name="TAccessModel">A model describing access to something.</typeparam>
    public interface IAccessService<TAccessModel> where TAccessModel: class
    {
        public Task GrantAccessAsync(GrantAccessModel<TAccessModel> grantAccessModel);

        public Task RevokeAccessAsync(RevokeAccessModel<TAccessModel> revokeAccessModel);

        public Task UpdateAccessAsync(UpdateAccessModel<TAccessModel> updateAccessModel);
        
    }
}
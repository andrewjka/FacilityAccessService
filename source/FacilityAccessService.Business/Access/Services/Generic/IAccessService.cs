using System.Threading.Tasks;
using FacilityAccessService.Business.Access.Actions.Generic;
using FacilityAccessService.Business.Object.Models;

namespace FacilityAccessService.Business.Access.Services.Generic
{
    /// <summary>
    /// Describes the service for the main cases with the specific accessed resource.
    /// </summary>
    /// <typeparam name="TAccessedResource">A model describing access to something.</typeparam>
    public interface IAccessService<TAccessedResource> where TAccessedResource: IAccessedResource
    {
        public Task GrantAccessAsync(GrantAccessModel<TAccessedResource> grantAccessModel);

        public Task RevokeAccessAsync(RevokeAccessModel<TAccessedResource> revokeAccessModel);

        public Task UpdateAccessAsync(UpdateAccessModel<TAccessedResource> updateAccessModel);
        
    }
}
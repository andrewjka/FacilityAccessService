using System.Threading.Tasks;
using FacilityAccessService.Business.AccessScope.Actions.Generic;
using FacilityAccessService.Business.ObjectScope.Models;

namespace FacilityAccessService.Business.AccessScope.Services.Generic
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
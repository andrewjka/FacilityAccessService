using System;
using System.Threading.Tasks;
using FacilityAccessService.Business.User.Models;

namespace FacilityAccessService.Business.User.Repositories
{
    public interface IUserClientRepository
    {
        public Task CreateAsync(UserClient userClient);

        public Task UpdateAsync(UserClient userClient);

        public Task GetByExternalIdAsync(string externalId);
        
        public Task GetByIdAsync(Guid id);
    }
}
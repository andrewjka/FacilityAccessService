using System;
using System.Threading.Tasks;
using FacilityAccessService.Business.Terminal.Models;

namespace FacilityAccessService.Business.Terminal.Repositories
{
    public interface ITerminalClientRepository
    {
        public Task CreateAsync(TerminalClient terminalClient);

        public Task UpdateAsync(TerminalClient terminalClient);
        
        public Task GetById(Guid id);
    }
}
using FacilityAccessService.Business.TerminalScope.Models;

namespace FacilityAccessService.Domain.Secure.CommonScope.Context
{
    public interface ITerminalContext
    {
        public Terminal Terminal { get; }
    }
}
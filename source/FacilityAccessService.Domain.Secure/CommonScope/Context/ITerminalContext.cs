#region

using FacilityAccessService.Business.TerminalScope.Models;

#endregion

namespace FacilityAccessService.Domain.Secure.CommonScope.Context
{
    public interface ITerminalContext
    {
        public Terminal Terminal { get; }
    }
}
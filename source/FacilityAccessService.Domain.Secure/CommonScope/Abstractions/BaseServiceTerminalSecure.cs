using System;
using FacilityAccessService.Domain.Secure.CommonScope.Context;

namespace FacilityAccessService.Domain.Secure.CommonScope.Abstractions
{
    public abstract class BaseServiceTerminalSecure
    {
        protected ITerminalContext _terminalContext;


        public BaseServiceTerminalSecure(ITerminalContext terminalContext)
        {
            if (terminalContext is null) throw new ArgumentNullException(nameof(terminalContext));

            this._terminalContext = terminalContext;

            EnsureTerminalNotNull();
        }


        protected void EnsureTerminalNotNull()
        {
            if (_terminalContext.Terminal is null)
            {
                throw new UnauthorizedAccessException(
                    "No terminal is associated with the current context. This operation requires an authenticated terminal."
                );
            }
        }
    }
}
#region

using System;
using Business.Secure.CommonScope.Context;

#endregion

namespace Business.Secure.CommonScope.Abstractions;

public abstract class BaseTerminalAuthorization
{
    protected ITerminalContext _terminalContext;


    public BaseTerminalAuthorization(ITerminalContext terminalContext)
    {
        if (terminalContext is null) throw new ArgumentNullException(nameof(terminalContext));

        _terminalContext = terminalContext;

        EnsureTerminalNotNull();
    }


    protected void EnsureTerminalNotNull()
    {
        if (_terminalContext.Terminal is null)
            throw new UnauthorizedAccessException(
                "No terminal is associated with the current context. This operation requires an authenticated terminal."
            );
    }
}
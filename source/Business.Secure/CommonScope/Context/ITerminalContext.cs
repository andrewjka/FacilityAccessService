using Domain.TerminalScope.Models;

namespace Business.Secure.CommonScope.Context;

public interface ITerminalContext
{
    public Terminal Terminal { get; }
}
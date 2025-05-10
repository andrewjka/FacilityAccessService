#region

using System.Threading.Tasks;
using Domain.TerminalScope.Models;
using Domain.TerminalScope.ValueObjects;

#endregion

namespace Domain.CommonScope.Services;

/// <summary>
///     Describes a service for verifying Terminal session.
/// </summary>
public interface ITerminalSessionService
{
    /// <summary>
    ///     Validates the token session and returns the Terminal if successful.
    /// </summary>
    /// <param name="token">Session token.</param>
    Task<Terminal> ValidateTokenAsync(TerminalToken token);
}
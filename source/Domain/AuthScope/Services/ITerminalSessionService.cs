using System.Threading.Tasks;
using Domain.CommonScope.ValueObjects;
using Domain.TerminalScope.Models;

namespace Domain.AuthScope.Services;

/// <summary>
///     Describes a service for verifying Terminal session.
/// </summary>
public interface ITerminalSessionService
{
    /// <summary>
    ///     Validates the token session and returns the Terminal if successful.
    /// </summary>
    /// <param name="token">Session token.</param>
    Task<Terminal> ValidateTokenAsync(Token512Bit token);
}
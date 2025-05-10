#region

using System.Threading.Tasks;
using Domain.UserScope.Models;

#endregion

namespace Domain.CommonScope.Services;

/// <summary>
///     Describes a service for verifying User session.
/// </summary>
public interface IUserSessionService
{
    /// <summary>
    ///     Validates the token session and returns the User if successful.
    /// </summary>
    /// <param name="token">Session token.</param>
    Task<User> ValidateTokenAsync(string token);
}
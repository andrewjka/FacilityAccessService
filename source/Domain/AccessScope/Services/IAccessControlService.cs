#region

using System.Threading.Tasks;
using Domain.AccessScope.Actions.Abstractions;

#endregion

namespace Domain.AccessScope.Services;

/// <summary>
///     Describes a service for verify User access to Facility.
/// </summary>
public interface IAccessControlService
{
    /// <summary>
    ///     Verifying access via specific access checker.
    /// </summary>
    public Task<bool> VerifyAccessAsync(VerifyAccessModel verifyAccessModel);
}
#region

using System.Threading.Tasks;
using Domain.AccessScope.Actions;

#endregion

namespace Domain.AccessScope.Services;

/// <summary>
///     Describes a service for verify User access to Facility.
/// </summary>
public interface IAccessService
{
    /// <summary>
    ///     Verifying access via specific access checker.
    /// </summary>
    public Task<bool> VerifyAccessAsync(VerifyAccessModel verifyAccessModel);
}
using FacilityAccessService.Business.AccessScope.Actions.Abstractions;

namespace FacilityAccessService.Business.AccessScope.Actions
{
    /// <inheritdoc/>
    public record VerifyAccessViaGuardModel(string GuarderId) : VerifyAccessModel;
}
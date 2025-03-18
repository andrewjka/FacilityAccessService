namespace FacilityAccessService.RestContract.Output.DTOs
{
    public record VerifyAccessViaGuardDTO(string UserId, string FacilityId, string GuardId);
}
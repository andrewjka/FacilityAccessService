namespace FacilityAccessService.RestContract.Output.DTOs
{
    public record VerifyAccessViaGuardRequest(
        string UserId,
        string FacilityId
    );
}
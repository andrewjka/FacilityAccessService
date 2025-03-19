namespace FacilityAccessService.RestContract.Output.DTOs
{
    public record VerifyAccessViaTerminalRequest(
        string UserId,
        string FacilityId,
        string TerminalToken
    );
}
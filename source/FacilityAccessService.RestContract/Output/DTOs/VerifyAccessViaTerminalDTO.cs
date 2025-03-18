namespace FacilityAccessService.RestContract.Output.DTOs
{
    public record VerifyAccessViaTerminalDTO(string UserId, string FacilityId, string TerminalToken);
}
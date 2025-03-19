using System;

namespace FacilityAccessService.RestContract.Output.DTOs
{
    public record UserCategory(
        string UserId,
        string CategoryId,
        DateTime StartDate,
        DateTime EndDate
    );
}
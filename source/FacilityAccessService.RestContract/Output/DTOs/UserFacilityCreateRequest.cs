using System;

namespace FacilityAccessService.RestContract.Output.DTOs
{
    public record UserFacilityCreateRequest(
        string UserId,
        string FacilityId,
        DateTime StartDate,
        DateTime EndDate
    );
}
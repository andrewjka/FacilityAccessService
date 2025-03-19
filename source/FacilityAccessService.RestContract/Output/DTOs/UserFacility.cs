using System;

namespace FacilityAccessService.RestContract.Output.DTOs
{
    public record UserFacility(
        string UserId,
        string FacilityId,
        DateTime StartDate,
        DateTime EndDate
    );
}
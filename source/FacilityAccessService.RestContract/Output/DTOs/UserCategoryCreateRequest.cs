using System;

namespace FacilityAccessService.RestContract.Output.DTOs
{
    public record UserCategoryCreateRequest(
        string UserId,
        string CategoryId,
        DateTime StartDate,
        DateTime EndDate
    );
}
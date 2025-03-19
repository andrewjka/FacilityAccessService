using System.Collections.Generic;

namespace FacilityAccessService.RestContract.Output.DTOs
{
    public record CategoryCreateRequest(
        string Name,
        List<int> Facilities
    );
}
using System.Collections.Generic;

namespace FacilityAccessService.RestContract.Output.DTOs
{
    public record Category(
        string Id,
        string Name,
        List<Facility> Facilities);
}
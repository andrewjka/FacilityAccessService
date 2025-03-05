using System;

namespace FacilityAccessService.Business.Object.Actions
{
    /// <summary>
    /// The action model for update the Object
    /// </summary>
    public record UpdateObjectModel(
        Guid ObjectId,
        string Name,
        string Description
    );
}
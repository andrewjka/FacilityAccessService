using System;

namespace FacilityAccessService.Business.ObjectScope.Actions
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
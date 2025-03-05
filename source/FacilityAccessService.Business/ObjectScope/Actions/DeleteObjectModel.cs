using System;

namespace FacilityAccessService.Business.ObjectScope.Actions
{
    /// <summary>
    /// The action model for delete the Object
    /// </summary>
    public record DeleteObjectModel(
        Guid ObjectId
    );
}
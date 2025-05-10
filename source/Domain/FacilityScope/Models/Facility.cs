#region

using Domain.CommonScope.Models;

#endregion

namespace Domain.FacilityScope.Models;

/// <summary>
///     Describes a facility in the access control system.
/// </summary>
public class Facility : BaseEntity, IAccessedResource
{
    public Facility(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public string Name { get; private set; }
    public string Description { get; private set; }

    /// <summary>
    ///     Changes the Facility name.
    /// </summary>
    public void ChangeName(string name)
    {
        Name = name;
    }

    /// <summary>
    ///     Changes the Facility description.
    /// </summary>
    public void ChangeDescription(string description)
    {
        Description = description;
    }
}
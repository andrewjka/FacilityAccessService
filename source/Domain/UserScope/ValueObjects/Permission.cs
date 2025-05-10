namespace Domain.UserScope.ValueObjects;

/// <summary>
///     Represents a permission that defines an action a user can perform.
/// </summary>
public record Permission
{
    // Has the ability to enter the facility
    public static readonly Permission CanEnterFacility = new("CanEnterFacility");

    // Has the ability to check access
    public static readonly Permission CanCheckPass = new("CanCheckPass");

    // Has the ability to do CRUD operations with category
    public static readonly Permission CanMaintenanceCategory = new("CanMaintenanceCategory");

    // Has the ability to do CRUD operations with object
    public static readonly Permission CanMaintenanceFacility = new("CanMaintenanceFacility");

    // Has the ability to do CRUD operations with terminal
    public static readonly Permission CanMaintenanceTerminal = new("CanMaintenanceTerminal");

    // Has the ability to grant and revoke access
    public static readonly Permission CanMaintenanceAccess = new("CanMaintenanceAccess");

    // Has the ability to do CRUD operations with users
    public static readonly Permission CanMaintenanceUsers = new("CanMaintenanceUsers");


    protected Permission(string name)
    {
        Name = name;
    }

    public string Name { get; init; }
}
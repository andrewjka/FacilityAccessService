namespace FacilityAccessService.Business.UserScope.ValueObjects
{
    /// <summary>
    /// Represents a permission that defines an action a user can perform.
    /// </summary>
    public record Permission
    {
        // Has the ability to enter the facility
        public static readonly Permission CanEnterFacility = new Permission("CanEnterFacility");

        // Has the ability to check access
        public static readonly Permission CanCheckPass = new Permission("CanCheckPass");

        // Has the ability to do CRUD operations with category
        public static readonly Permission CanMaintenanceCategory = new Permission("CanMaintenanceCategory");

        // Has the ability to do CRUD operations with object
        public static readonly Permission CanMaintenanceFacility = new Permission("CanMaintenanceFacility");

        // Has the ability to do CRUD operations with terminal
        public static readonly Permission CanMaintenanceTerminal = new Permission("CanMaintenanceTerminal");

        // Has the ability to grant and revoke access to facilities
        public static readonly Permission CanMaintenanceAccess = new Permission("CanMaintenanceAccess");
        
        // Has the ability to do CRUD operations with users
        public static readonly Permission CanMaintenanceUsers = new Permission("CanMaintenanceUsers");

        protected Permission(string name)
        {
            Name = name;
        }

        public string Name { get; init; }
    }
}
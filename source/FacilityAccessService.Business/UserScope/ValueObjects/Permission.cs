namespace FacilityAccessService.Business.UserScope.ValueObjects
{
    /// <summary>
    /// Represents a permission that defines an action a user can perform.
    /// </summary>
    public record Permission
    {
        public string Name { get; init; }

        protected Permission(string name)
        {
            Name = name;
        }
        
        // Has the ability to enter the facility
        public static readonly Permission CanEnterObject = new Permission("CanEnterObject");
        
        // Has the ability to check access
        public static readonly Permission CanCheckPass = new Permission("CanCheckPass");
        
        // Has the ability to do CRUD operations with category
        public static readonly Permission CanMaintenanceCategory = new Permission("CanMaintenanceCategory");
        
        // Has the ability to do CRUD operations with object
        public static readonly Permission CanMaintenanceObject = new Permission("CanMaintenanceObject");
        
        // Has the ability to grant and revoke access to facilities
        public static readonly Permission CanMaintenanceAccess = new Permission("CanMaintenanceAccess");
    }
}
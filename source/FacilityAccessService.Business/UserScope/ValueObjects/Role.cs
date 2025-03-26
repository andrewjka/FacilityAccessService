#region

using System.Collections.Generic;
using System.Collections.ObjectModel;

#endregion

namespace FacilityAccessService.Business.UserScope.ValueObjects
{
    /// <summary>
    /// Represents a role that defines a set of permissions for user.
    /// </summary>
    public record Role
    {
        public readonly string Name;
        public readonly ReadOnlyCollection<Permission> Permissions;


        protected Role(string name, ReadOnlyCollection<Permission> permissions)
        {
            this.Name = name;
            this.Permissions = permissions;
        }


        public bool CheckPermission(Permission permission)
        {
            return CheckPermission(this, permission);
        }


        public static bool CheckPermission(Role role, Permission permission)
        {
            return role.Permissions.Contains(permission);
        }

        public static Role GetRoleByName(string name)
        {
            switch (name.ToLower())
            {
                case ("guest"):
                    return Guest;

                case ("employee"):
                    return Employee;

                case ("guard"):
                    return Guard;

                case ("administrator"):
                    return Administrator;

                default:
                    return Guest;
            }
        }


        public static readonly Role Guest = new Role(
            name: "Guest",
            permissions: new List<Permission>()
            {
            }.AsReadOnly()
        );

        public static readonly Role Employee = new Role(
            name: "Employee",
            permissions: new List<Permission>()
            {
                Permission.CanEnterFacility
            }.AsReadOnly()
        );

        public static readonly Role Guard = new Role(
            name: "Guard",
            permissions: new List<Permission>()
            {
                Permission.CanEnterFacility, Permission.CanCheckPass
            }.AsReadOnly()
        );

        public static readonly Role Administrator = new Role(
            name: "Administrator",
            permissions: new List<Permission>()
            {
                Permission.CanEnterFacility, Permission.CanCheckPass,
                Permission.CanMaintenanceFacility, Permission.CanMaintenanceCategory,
                Permission.CanMaintenanceAccess, Permission.CanMaintenanceTerminal,
                Permission.CanMaintenanceUsers
            }.AsReadOnly()
        );
    }
}
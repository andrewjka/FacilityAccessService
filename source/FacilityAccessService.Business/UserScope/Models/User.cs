#region

using FacilityAccessService.Business.UserScope.ValueObjects;

#endregion

namespace FacilityAccessService.Business.UserScope.Models
{
    /// <summary>
    /// Describes a user in the access control system.
    /// </summary>
    public class User
    {
        public User(string externalUserId, Role role = null) : base()
        {
            this.Id = externalUserId;
            this.Role = role ?? Role.Guest;
        }

        public string Id { get; private set; }
        public Role Role { get; private set; }

        public void ChangeRole(Role role)
        {
            this.Role = role;
        }
    }
}
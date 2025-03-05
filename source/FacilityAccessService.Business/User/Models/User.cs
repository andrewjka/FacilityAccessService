using System;
using FacilityAccessService.Business.Common;
using FacilityAccessService.Business.Common.ValueObjects;

namespace FacilityAccessService.Business.User.Models
{
    /// <summary>
    /// Describes a user in the access control system.
    /// </summary>
    public class User : BaseEntity
    {
        public string ExternalUserId { get; private set; }
        public Role Role { get; private set; }


        public User(string externalUserId, Role role = null) : base()
        {
            this.ExternalUserId = externalUserId;
            this.Role = role ?? Role.Guest;
        }

        public void ChangeRole(Role role)
        {
            this.Role = role;
        }
    }
}
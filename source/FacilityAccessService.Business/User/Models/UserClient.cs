using System;
using FacilityAccessService.Business.Common;
using FacilityAccessService.Business.Common.ValueObjects;

namespace FacilityAccessService.Business.User.Models
{
    /// <summary>
    /// Describes a user in the access control system.
    /// </summary>
    public class UserClient : BaseEntity
    {
        public string ExternalUserId { get; private set; }
        public Role Role { get; private set; }


        public UserClient(Guid id, string externalUserId, Role role = null)
        {
            this.Id = id;
            this.ExternalUserId = externalUserId;
            this.Role = role ?? Role.Guest;
        }

        public void ChangeRole(Role role)
        {
            this.Role = role;
        }
    }
}
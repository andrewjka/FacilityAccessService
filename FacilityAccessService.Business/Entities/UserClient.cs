using System;
using FacilityAccessService.Business.ValueObjects;

namespace FacilityAccessService.Business.Entities
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
    }
}
using System.Collections.ObjectModel;
using FacilityAccessService.Business.Common.ValueObjects;
using FacilityAccessService.Business.User.Models;

namespace FacilityAccessService.Business.Access.Models
{
    public class UserClientObjects
    {
        public UserClient UserClient { get; private set; }
        public ReadOnlyCollection<Object.Models.Object> Objects { get; private set; }
        public AccessPeriod AccessPeriod { get; private set; }


        public UserClientObjects(
            UserClient userClient,
            ReadOnlyCollection<Object.Models.Object> objects,
            AccessPeriod accessPeriod)
        {
            this.UserClient = UserClient;
            this.Objects = objects;
            this.AccessPeriod = accessPeriod;
        }
    }
}
using System.Collections.ObjectModel;
using FacilityAccessService.Business.ValueObjects;

namespace FacilityAccessService.Business.Entities
{
    public class UserClientObjects
    {
        public UserClient UserClient { get; private set; }
        public ReadOnlyCollection<Object> Objects { get; private set; }
        public AccessPeriod AccessPeriod { get; private set; }


        public UserClientObjects(
            UserClient userClient,
            ReadOnlyCollection<Object> objects,
            AccessPeriod accessPeriod)
        {
            this.UserClient = UserClient;
            this.Objects = objects;
            this.AccessPeriod = accessPeriod;
        }
    }
}
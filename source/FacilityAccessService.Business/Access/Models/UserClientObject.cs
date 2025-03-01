using System.Collections.ObjectModel;
using FacilityAccessService.Business.Common.ValueObjects;
using FacilityAccessService.Business.User.Models;

namespace FacilityAccessService.Business.Access.Models
{
    public class UserClientObject
    {
        public UserClient UserClient { get; private set; }
        public Object.Models.Object Object { get; private set; }
        public AccessPeriod AccessPeriod { get; private set; }


        public UserClientObject(
            UserClient userClient,
            Object.Models.Object facility,
            AccessPeriod accessPeriod)
        {
            this.UserClient = userClient;
            this.Object = facility;
            this.AccessPeriod = accessPeriod;
        }
    }
}
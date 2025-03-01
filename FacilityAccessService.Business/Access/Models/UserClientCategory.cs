using System.Collections.ObjectModel;
using FacilityAccessService.Business.Common.ValueObjects;
using FacilityAccessService.Business.Object.Models;
using FacilityAccessService.Business.User.Models;

namespace FacilityAccessService.Business.Access.Models
{
    public class UserClientCategory
    {
        public UserClient UserClient { get; private set; }
        public Category Category { get; private set; }
        public AccessPeriod AccessPeriod { get; private set; }


        public UserClientCategory(
            UserClient userClient,
            Category category,
            AccessPeriod accessPeriod)
        {
            this.UserClient = userClient;
            this.Category = category;
            this.AccessPeriod = accessPeriod;
        }
    }
}
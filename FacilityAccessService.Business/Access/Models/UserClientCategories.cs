using System.Collections.ObjectModel;
using FacilityAccessService.Business.Common.ValueObjects;
using FacilityAccessService.Business.Object.Models;
using FacilityAccessService.Business.User.Models;

namespace FacilityAccessService.Business.Access.Models
{
    public class UserClientCategories
    {
        public UserClient UserClient { get; private set; }
        public ReadOnlyCollection<Category> Categories { get; private set; }
        public AccessPeriod AccessPeriod { get; private set; }


        public UserClientCategories(
            UserClient userClient,
            ReadOnlyCollection<Category> categories,
            AccessPeriod accessPeriod)
        {
            this.UserClient = UserClient;
            this.Categories = categories;
            this.AccessPeriod = accessPeriod;
        }
    }
}
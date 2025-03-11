using FacilityAccessService.Business.UserScope.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FacilityAccessService.Persistence.UserScope.Converters
{
    public class RoleConverter : ValueConverter<Role, string>
    {
        public RoleConverter(
        ) : base(
            ToProvider => ToProvider.Name,
            FromProvider => Role.GetRoleByName(FromProvider)
        )
        {
        }
    }
}
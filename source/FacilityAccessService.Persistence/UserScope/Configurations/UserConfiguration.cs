using FacilityAccessService.Persistence.UserScope.Converters;
using FacilityAccessService.Persistence.UserScope.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FacilityAccessService.Persistence.UserScope.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(entity => entity.Id);

            builder.Property(entity => entity.Role)
                .IsRequired()
                .HasConversion<RoleConverter>();
        }
    }
}
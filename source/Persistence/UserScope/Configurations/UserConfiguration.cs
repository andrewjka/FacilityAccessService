using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.UserScope.Converters;
using Persistence.UserScope.Models;

namespace Persistence.UserScope.Configurations;

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
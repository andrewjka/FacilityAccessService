using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.CommonScope.Configuration;
using Persistence.FacilityScope.Models;

namespace Persistence.FacilityScope.Configurations;

public class FacilityConfiguration : BaseEntityConfiguration<Facility>, IEntityTypeConfiguration<Facility>
{
    public new void Configure(EntityTypeBuilder<Facility> builder)
    {
        base.Configure(builder);

        builder.HasIndex(entity => entity.Name).IsUnique();
    }
}
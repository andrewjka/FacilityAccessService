using FacilityAccessService.Persistence.CommonScope.Configuration;
using FacilityAccessService.Persistence.FacilityScope.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FacilityAccessService.Persistence.FacilityScope.Configurations
{
    public class FacilityConfiguration : BaseEntityConfiguration<Facility>, IEntityTypeConfiguration<Facility>
    {
        public new void Configure(EntityTypeBuilder<Facility> builder)
        {
            base.Configure(builder);

            builder.HasIndex(entity => entity.Name).IsUnique();
        }
    }
}
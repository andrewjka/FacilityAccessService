using FacilityAccessService.Persistence.FacilityScope.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FacilityAccessService.Persistence.FacilityScope.Configurations
{
    public class CategoryFacilityConfiguration : IEntityTypeConfiguration<CategoryFacility>
    {
        public void Configure(EntityTypeBuilder<CategoryFacility> builder)
        {
            builder.HasKey(entity => new { entity.CategoryId, entity.FacilityId });

            builder.HasOne(entity => entity.Category)
                .WithMany()
                .HasForeignKey(entity => entity.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(entity => entity.Facility)
                .WithMany()
                .HasForeignKey(entity => entity.FacilityId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
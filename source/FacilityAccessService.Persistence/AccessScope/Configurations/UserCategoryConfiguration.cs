using FacilityAccessService.Persistence.AccessScope.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FacilityAccessService.Persistence.AccessScope.Configurations
{
    public class UserCategoryConfiguration : IEntityTypeConfiguration<UserCategory>
    {
        public void Configure(EntityTypeBuilder<UserCategory> builder)
        {
            builder.HasKey(entity => new { entity.UserId, entity.CategoryId });


            builder.HasOne(entity => entity.User)
                .WithMany()
                .HasForeignKey(entity => entity.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(entity => entity.Category)
                .WithMany()
                .HasForeignKey(entity => entity.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.OwnsOne(entity => entity.AccessPeriod, cfg =>
            {
                cfg.Property(entity => entity.StartDate).IsRequired();
                cfg.Property(entity => entity.EndDate).IsRequired();
            });
        }
    }
}
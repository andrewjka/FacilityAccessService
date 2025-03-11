using FacilityAccessService.Persistence.AccessScope.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserFacilityConfiguration : IEntityTypeConfiguration<UserFacility>
{
    public void Configure(EntityTypeBuilder<UserFacility> builder)
    {
        builder.HasKey(entity => new { entity.UserId, entity.FacilityId });


        builder.HasOne(entity => entity.User)
            .WithMany()
            .HasForeignKey(entity => entity.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(entity => entity.Facility)
            .WithMany()
            .HasForeignKey(entity => entity.FacilityId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.OwnsOne(entity => entity.AccessPeriod, cfg =>
        {
            cfg.Property(entity => entity.StartDate).IsRequired();
            cfg.Property(entity => entity.EndDate).IsRequired();
        });
    }
}
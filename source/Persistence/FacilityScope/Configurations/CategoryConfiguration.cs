using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.CommonScope.Configuration;
using Persistence.FacilityScope.Models;

namespace Persistence.FacilityScope.Configurations;

public class CategoryConfiguration : BaseEntityConfiguration<Category>, IEntityTypeConfiguration<Category>
{
    public new void Configure(EntityTypeBuilder<Category> builder)
    {
        base.Configure(builder);

        builder.HasIndex(entity => entity.Name).IsUnique();

        builder.HasMany(entity => entity.Facilities)
            .WithMany()
            .UsingEntity<CategoryFacility>();

        builder.Navigation(entity => entity.Facilities).AutoInclude();
    }
}
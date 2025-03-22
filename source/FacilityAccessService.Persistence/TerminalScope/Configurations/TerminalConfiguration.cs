using FacilityAccessService.Persistence.CommonScope.Configuration;
using FacilityAccessService.Persistence.TerminalScope.Converters;
using FacilityAccessService.Persistence.TerminalScope.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FacilityAccessService.Persistence.TerminalScope.Configurations
{
    public class TerminalConfiguration : BaseEntityConfiguration<Terminal>, IEntityTypeConfiguration<Terminal>
    {
        public new void Configure(EntityTypeBuilder<Terminal> builder)
        {
            base.Configure(builder);

            builder.Property(entity => entity.Name)
                .IsRequired();

            builder.Property(entity => entity.Token)
                .HasConversion<TerminalTokenConverter>()
                .IsRequired();

            builder.Property(entity => entity.ExpiredTokenOn)
                .IsRequired();
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.CommonScope.Configuration;
using Persistence.CommonScope.Converters;
using Persistence.TerminalScope.Models;

namespace Persistence.TerminalScope.Configurations;

public class TerminalConfiguration : BaseEntityConfiguration<Terminal>, IEntityTypeConfiguration<Terminal>
{
    public new void Configure(EntityTypeBuilder<Terminal> builder)
    {
        base.Configure(builder);

        builder.Property(entity => entity.Name)
            .IsRequired();

        builder.Property(entity => entity.Token)
            .HasConversion<Token512BitConverter>()
            .IsRequired();

        builder.Property(entity => entity.ExpiredTokenOn)
            .IsRequired();
    }
}
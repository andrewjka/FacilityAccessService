using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.AuthScope.Models;
using Persistence.CommonScope.Converters;

namespace Persistence.AuthScope.Confugirations;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.HasKey(entity => new { entity.UserId, entity.Token });

        builder.HasOne(entity => entity.User)
            .WithMany()
            .HasForeignKey(entity => entity.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(entity => entity.Token)
            .HasConversion<Token512BitConverter>();

        builder.HasIndex(entity => entity.Token).IsUnique();
    }
}
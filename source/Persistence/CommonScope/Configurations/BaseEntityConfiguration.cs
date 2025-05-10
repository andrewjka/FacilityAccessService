using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.CommonScope.Models;

namespace Persistence.CommonScope.Configuration;

public abstract class BaseEntityConfiguration<TEntityDB> : IEntityTypeConfiguration<TEntityDB>
    where TEntityDB : BaseEntity
{
    public void Configure(EntityTypeBuilder<TEntityDB> builder)
    {
        builder.HasKey(entity => entity.Id);
    }
}
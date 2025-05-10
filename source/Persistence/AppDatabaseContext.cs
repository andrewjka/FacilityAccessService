using Microsoft.EntityFrameworkCore;
using Persistence.AccessScope.Models;
using Persistence.FacilityScope.Models;
using Persistence.TerminalScope.Models;
using Persistence.UserScope.Models;

namespace Persistence;

public class AppDatabaseContext : DbContext
{
    public AppDatabaseContext(DbContextOptions<AppDatabaseContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Terminal> Terminals { get; set; }
    public DbSet<Facility> Facilities { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<CategoryFacility> CategoryFacilities { get; set; }
    public DbSet<UserCategory> UserCategories { get; set; }
    public DbSet<UserFacility> UserFacilities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDatabaseContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

        optionsBuilder.EnableSensitiveDataLogging();
    }
}
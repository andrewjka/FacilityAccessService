using FacilityAccessService.Business.TerminalScope.ValueObjects;
using FacilityAccessService.Persistence.AccessScope.Models;
using FacilityAccessService.Persistence.FacilityScope.Models;
using FacilityAccessService.Persistence.TerminalScope.Configurations;
using FacilityAccessService.Persistence.TerminalScope.Models;
using FacilityAccessService.Persistence.UserScope.Models;
using Microsoft.EntityFrameworkCore;

namespace FacilityAccessService.Persistence
{
    public class AppDatabaseContext : DbContext
    {
        public AppDatabaseContext(DbContextOptions<AppDatabaseContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Terminal> Terminals { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserCategory> UserCategories { get; set; }
        public DbSet<UserFacility> UserFacilities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDatabaseContext).Assembly);
        }
    }
}
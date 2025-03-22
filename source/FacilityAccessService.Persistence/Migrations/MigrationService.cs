using Microsoft.EntityFrameworkCore;

namespace FacilityAccessService.Persistence.Migrations
{
    public class MigrationService
    {
        private readonly AppDatabaseContext _context;


        public MigrationService(AppDatabaseContext context)
        {
            this._context = context;
        }
        
        public void ApplyMigrations()
        {
            _context.Database.Migrate();
        }
    }
}
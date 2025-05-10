using Microsoft.EntityFrameworkCore;

namespace Persistence.Migrations;

public class MigrationService
{
    private readonly AppDatabaseContext _context;


    public MigrationService(AppDatabaseContext context)
    {
        _context = context;
    }

    public void ApplyMigrations()
    {
        _context.Database.Migrate();
    }
}
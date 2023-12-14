using Authorization.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Authorization.DataAccess;

public class AuthorizationContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public AuthorizationContext(DbContextOptions<AuthorizationContext> options) : base(options)
    {
        try
        {
            if (Database.GetService<IDatabaseCreator>() is RelationalDatabaseCreator databaseCreator)
            {
                if (!databaseCreator.CanConnect()) databaseCreator.Create();
                if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace finalProject.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            
            // For design-time (migrations), use connection string from environment or appsettings
            // In production, this will be overridden by Program.cs with Key Vault
            var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection")
                ?? "Server=tcp:najdi-sql.database.windows.net,1433;Database=husseinnajdi-db;Authentication=Active Directory Default;Encrypt=True;TrustServerCertificate=False;";

            optionsBuilder.UseSqlServer(connectionString);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}


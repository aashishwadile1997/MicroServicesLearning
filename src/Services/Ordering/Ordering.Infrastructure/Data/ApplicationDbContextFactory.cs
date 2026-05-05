using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Ordering.Infrastructure.Data
{
    public class ApplicationDbContextFactory
        : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            optionsBuilder.UseSqlServer(
                "Server=localhost;Database=Orderdb;User Id=sa;Password=Ashish12345678;Encrypt=False;TrustServerCertificate=True;Encrypt=True;");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
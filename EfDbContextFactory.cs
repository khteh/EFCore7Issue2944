using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreNullBug
{
    public class EfDbContextFactory : IDesignTimeDbContextFactory<EfDbContext>
    {
        public EfDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EfDbContext>();
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            var dbServer = configuration["DatabaseConnection:Server"];
            var dbPort = configuration["DatabaseConnection:Port"];
            var dbDatabase = configuration["DatabaseConnection:Database"];
            var dbUserId = configuration["DatabaseConnection:User Id"];
            var dbPassword = configuration["DatabaseConnection:Password"];
            var connectionString = $"Server={dbServer};Port={dbPort};Database={dbDatabase};User Id={dbUserId};Password={dbPassword}";
            optionsBuilder.UseNpgsql(connectionString);
            return new EfDbContext(optionsBuilder.Options);
        }
    }
}

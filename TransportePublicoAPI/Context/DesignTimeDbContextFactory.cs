using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace TransportePublicoAPI.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TransporteDbContext>
    {
        public TransporteDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TransporteDbContext>();

            // Obtén la cadena de conexión desde appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("TransporteDbConnection"));

            return new TransporteDbContext(optionsBuilder.Options);
        }
    }
}

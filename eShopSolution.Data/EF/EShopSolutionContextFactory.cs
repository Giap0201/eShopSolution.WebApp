using eShopSolution.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

public class EShopSolutionContextFactory : IDesignTimeDbContextFactory<EShopDbContext>
{
    public EShopDbContext CreateDbContext(string[] args)
    {
        var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../eShopSolution.Data");

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("eShopSolutionDb");

        var optionsBuilder = new DbContextOptionsBuilder<EShopDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new EShopDbContext(optionsBuilder.Options);
    }
}

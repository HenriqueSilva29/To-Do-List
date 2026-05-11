using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Repository.ContextosEF
{
    public class ContextEFFactory : IDesignTimeDbContextFactory<ContextEF>
    {
        public ContextEF CreateDbContext(string[] args)
        {
            var basePath = args.Length > 0
                ? args[0]
                : ResolveApiProjectPath();

            Console.WriteLine($"Base path usado: {basePath}");

            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .AddJsonFile("appsettings.Local.json", optional: true)
                .AddJsonFile($"appsettings.{environment}.Local.json", optional: true)
                .AddEnvironmentVariables();

            var config = builder.Build();

            var connectionString = config.GetConnectionString("DefaultConnection");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException(
                    "Connection string 'DefaultConnection' nao configurada.");
            }

            var optionsBuilder = new DbContextOptionsBuilder<ContextEF>();
            optionsBuilder.UseSqlServer(connectionString);

            return new ContextEF(optionsBuilder.Options);
        }

        private static string ResolveApiProjectPath()
        {
            var currentDirectory = Directory.GetCurrentDirectory();

            if (File.Exists(Path.Combine(currentDirectory, "appsettings.json")))
                return currentDirectory;

            var apiPath = Path.Combine(currentDirectory, "API");

            return Directory.Exists(apiPath)
                ? apiPath
                : currentDirectory;
        }
    }
}


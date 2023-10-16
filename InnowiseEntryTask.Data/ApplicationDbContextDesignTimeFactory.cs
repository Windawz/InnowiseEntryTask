using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace InnowiseEntryTask.Data;

internal class ApplicationDbContextDesignTimeFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    private const string DefaultAppSettingsFileName = @"../InnowiseEntryTask.WebApi/appsettings.json";

    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var (appSettingsFileName, connectionStringName) = ExtractArgs(args);

        var configuration = new ConfigurationBuilder()
            .AddJsonFile(appSettingsFileName)
            .Build();

        var connectionString = configuration.GetConnectionString(connectionStringName)
            ?? throw new ArgumentException("Could not find connection string with the provided name");

        var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer(connectionString: connectionString)
            .Options;

        return new ApplicationDbContext(dbContextOptions);
    }

    private static (string appSettingsFileName, string connectionStringName) ExtractArgs(string[] args)
    {
        string appSettingsFileName = args.Length > 1
            ? ParseAppSettingsFileName(args[0])
            : DefaultAppSettingsFileName;

        string connectionStringName = args.Length > 1
            ? ParseConnectionStringName(args[1])
            : args.Length > 0
                ? ParseConnectionStringName(args[0])
                : throw new ArgumentException(
                    message: "Expected at least one command line argument for connection string name",
                    paramName: nameof(args)
                );
        
        return (appSettingsFileName, connectionStringName);
    }

    private static string ParseAppSettingsFileName(string arg) =>
        Path.GetFullPath(arg.Trim());

    private static string ParseConnectionStringName(string arg) =>
        arg.Trim();
}
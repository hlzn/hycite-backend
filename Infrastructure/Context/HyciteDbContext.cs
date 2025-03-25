namespace Hycite.Data;

using Hycite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class HyciteDbContextFactory : IDesignTimeDbContextFactory<HyciteDbContext>
{
    private IConfiguration? _configuration;

    private IConfiguration GetAppConfiguration()
    {
        var environmentName = Environment.GetEnvironmentVariable(
                      "ASPNETCORE_ENVIRONMENT");

        var path = Directory.GetCurrentDirectory();
        var builder = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentName}.json", true)
                .AddEnvironmentVariables();

        return builder.Build();
    }

    public HyciteDbContext CreateDbContext(string[] args)
    {
        _configuration = GetAppConfiguration();
        var optionsBuilder = new DbContextOptionsBuilder<HyciteDbContext>();
        optionsBuilder.UseSqlite(_configuration.GetConnectionString("SqlLiteConnection"));

        return new HyciteDbContext(optionsBuilder.Options);
    }
}

public class HyciteDbContext : DbContext
{
    public HyciteDbContext(DbContextOptions<HyciteDbContext> options) : base(options)
    {
    }

    public DbSet<AccessLevel> AccessLevels { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Goal> Goals { get; set; }
    public DbSet<Hierarchy> Hierarchies { get; set; }
    public DbSet<ProspectSource> ProspectSources { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserActivity> UserActivities { get; set; }
    public DbSet<UserSecurity> UserSecurities { get; set; }
    public DbSet<UserType> UserTypes { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hierarchy>()
            .HasKey(h => new { h.ParentId, h.ChildId });
    }
}
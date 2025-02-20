namespace Hycite.Data;

using Hycite.Models;
using Microsoft.EntityFrameworkCore;

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
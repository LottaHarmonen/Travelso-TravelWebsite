using Microsoft.EntityFrameworkCore;
using Travelso_Website_Shared.Entities;

namespace Travelso_Website.DataAccess;

public class TravelsoSQLDataContext : DbContext
{
    public DbSet<BlogPost> BlogPosts { get; set; }
    public DbSet<Comment?> Comments { get; set; }

    public DbSet<Country> Countries { get; set; }
    public DbSet<Destination> Destinations { get; set; }

    public DbSet<TravelsoUser> TravelsoUsers { get; set; }

    public TravelsoSQLDataContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }

}
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Country> Countries { get; set; }

    public DbSet<Province> Provinces { get; set; }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>().HasData(SeedData.Countries);

        modelBuilder.Entity<Province>().HasData(SeedData.Provinces);
    }
}
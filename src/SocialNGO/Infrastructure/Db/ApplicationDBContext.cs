using Microsoft.EntityFrameworkCore;
using SocialNGO.Infrastructure.Db.Entities;

namespace SocialNGO.Infrastructure.Db;

/// <summary></summary>
public class ApplicationDBContext : DbContext
{
    /// <summary>
    /// Default Constructor
    /// </summary>


    /// <summary> </summary>
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {

    }
    /// <summary></summary>
    public DbSet<User> Users { get; set; }
    public DbSet<UserLogin> UserLogins { get; set; }
    public DbSet<UserRegistration> UserRegistrations { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<BloodGroup> BloodGroups { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<State> States { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Designation> Designations { get; set; }

    public DbSet<PasswordHistroy> PasswordHistroys { get; set; }

    public DbSet<PostingCity> PostingCities { get; set; }
    public DbSet<PostingBlock> PostingBlocks { get; set; }
    public DbSet<PostingState> PostingStates { get; set; }
    public DbSet<Region> Region { get; set; }
    public DbSet<Roles> Role { get; set; }

}

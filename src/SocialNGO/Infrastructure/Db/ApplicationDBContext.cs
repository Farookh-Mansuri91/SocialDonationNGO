using Microsoft.EntityFrameworkCore;

namespace SocialNGO.Infrastructure.Db;

/// <summary></summary>
public class ApplicationDBContext : DbContext
{
    /// <summary>
    /// Default Constructor
    /// </summary>
    public ApplicationDBContext()
    {

    }

    /// <summary> </summary>
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {

    }
}

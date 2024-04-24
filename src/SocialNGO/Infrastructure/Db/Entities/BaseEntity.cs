using System.ComponentModel.DataAnnotations;

namespace SocialNGO.Infrastructure.Db.Entities;

/// <summary> </summary>
public class BaseEntity
{
    /// <summary>It is a primary key (Auto Generate)</summary>
    [Key]
    public int Id { get; set; }

    /// <summary> </summary>
    public int Author { get; set; }

    /// <summary> </summary>
    [DataType(DataType.DateTime)]
    public DateTime Created_date { get; set; }

    /// <summary> </summary>
    [DataType(DataType.DateTime)]
    public DateTime Updatated_date { get; set; }

    /// <summary> </summary>
    public BaseEntity()
    {
        Created_date = DateTime.UtcNow;
    }
}

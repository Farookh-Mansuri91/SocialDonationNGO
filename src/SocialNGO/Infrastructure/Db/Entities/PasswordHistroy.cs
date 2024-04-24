namespace SocialNGO.Infrastructure.Db.Entities;

/// <summary> </summary>
public class PasswordHistroy : BaseEntity
{
    /// <summary> </summary>
    public string? Hash { get; set; }

    /// <summary> </summary>
    public string? Salt { get; set; }

    /// <summary> </summary>
    public int UserId { get; set; }
}

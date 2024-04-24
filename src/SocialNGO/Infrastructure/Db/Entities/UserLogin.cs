using SocialNGO.Common.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNGO.Infrastructure.Db.Entities;

/// <summary> </summary>
[Table(TableSchema.UserLogin)]
public class UserLogin : BaseEntity
{
    /// <summary>
    /// 
    /// </summary>
    /// <summary> </summary>
    public string? Name { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <summary> </summary>
    public string UserPassword { get; set; }


    /// <summary> </summary>
    public string PasswordHash { get; set; } 

    /// <summary> </summary>
    public string EmailId { get; set; }

    /// <summary> </summary>
    public string Token { get; set; }

    /// <summary> </summary>
    public DateTime RegistrationDate { get; set; }

    /// <summary> </summary>
    public DateTime LastLogin { get; set; }

}

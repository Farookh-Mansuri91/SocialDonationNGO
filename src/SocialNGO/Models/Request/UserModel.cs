using System.ComponentModel.DataAnnotations;

namespace SocialNGO.Models.Request;

/// <summary> </summary>
public class UserModel
{
    /// <summary> </summary>
    public Guid Id { get; set; }

    /// <summary> </summary>
    [Required(ErrorMessage = "School Name is required")]
    [MinLength(5), MaxLength(255)]
    public string? SchoolName { get; set; }

    /// <summary> </summary>
    [Required(ErrorMessage = "Address is required")]
    public string? Address { get; set; }

    /// <summary> </summary>
    [Required(ErrorMessage = "Contact is required")]
    public string? Contact { get; set; }

    /// <summary> </summary>
    public string? AlternateContact { get; set; }
}

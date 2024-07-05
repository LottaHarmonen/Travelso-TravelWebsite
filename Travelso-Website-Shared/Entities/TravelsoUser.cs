using System.ComponentModel.DataAnnotations;

namespace Travelso_Website_Shared.Entities;

public class TravelsoUser
{
    [Key]
    public string? UserId { get; set; }
    public string? UserName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }

    public string? ProfileImage { get; set; }

    public virtual ICollection<Country> MyVisitedCountries { get; set; }
    public virtual ICollection<BlogPost> BlogPosts { get; set; }
}
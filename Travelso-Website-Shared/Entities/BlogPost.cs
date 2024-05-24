using System.ComponentModel.DataAnnotations;

namespace Travelso_Website_Shared.Entities;

public class BlogPost
{
    [Key]
    public int BlogPostId { get; set; }
    [Required]
    public string Title { get; set; }

    public string ImageUrl { get; set; }

    [Required]
    public TravelsoUser TravelsoUser { get; set; }

    [Required]
    public DateTime PublishedDate { get; set; }

    [Required]
    public string HtmlContent { get; set; }

    [Required]
    public int CountryId { get; set; }

    public virtual ICollection<Comment> Comments { get; set; }
}
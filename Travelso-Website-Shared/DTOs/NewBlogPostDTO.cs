using System.ComponentModel.DataAnnotations;
using Travelso_Website_Shared.Entities;

namespace Travelso_Website_Shared.DTOs;

public class NewBlogPostDTO
{
    public string Title { get; set; }
    public string ImageUrl { get; set; }
    public int UserId { get; set; }
    public DateTime PublishedDate { get; set; }
    public string HtmlContent { get; set; }

}
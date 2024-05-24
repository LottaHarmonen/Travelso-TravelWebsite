using System.ComponentModel.DataAnnotations;

namespace Travelso_Website_Shared.Entities;

public class Comment
{
    [Key]
    public int CommentId { get; set; }

    public string comment { get; set; }

    public TravelsoUser TravelsoUser { get; set; }

    public DateTime publicationDate { get; set; }

}
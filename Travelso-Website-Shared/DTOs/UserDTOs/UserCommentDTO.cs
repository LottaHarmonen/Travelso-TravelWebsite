namespace Travelso_Website_Shared.DTOs.UserDTOs;

public class UserCommentDTO
{
    public int CommentId { get; set; }

    public string comment { get; set; }

    public string username { get; set; }

    public string userImageURL { get; set; }

    public int BlogPostId { get; set; }

    public DateTime publicationDate { get; set; }
}
using Travelso_Website_Shared.DTOs.UserDTOs;
using Travelso_Website_Shared.Entities;

namespace Travelso_Website_Shared.Interfaces.IService;

public interface ICommentService : IGenericService<Comment>
{
    Task<List<UserCommentDTO>?>? CommentsByBlogPost(int blogPostId);
}
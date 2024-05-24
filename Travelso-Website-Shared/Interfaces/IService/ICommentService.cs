using Travelso_Website_Shared.Entities;

namespace Travelso_Website_Shared.Interfaces.IService;

public interface ICommentService : IGenericService<Comment>
{
    Task<IEnumerable<Comment>> CommentsByBlogPost(int blogPostId);
}
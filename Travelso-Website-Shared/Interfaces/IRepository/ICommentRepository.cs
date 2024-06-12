using Travelso_Website_Shared.Entities;

namespace Travelso_Website_Shared.Interfaces.IRepository;

public interface ICommentRepository : IRepository<Comment>
{
    Task<IEnumerable<Comment>?>? CommentsByBlogPost(int blogPostId);
}
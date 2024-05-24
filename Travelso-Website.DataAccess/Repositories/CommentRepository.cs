using Microsoft.EntityFrameworkCore;
using Travelso_Website_Shared.Entities;
using Travelso_Website_Shared.Interfaces.IService;

namespace Travelso_Website.DataAccess.Repositories;

public class CommentRepository : ICommentService
{
    private readonly TravelsoSQLDataContext _sqlDataContext;

    public CommentRepository(TravelsoSQLDataContext context)
    {
        _sqlDataContext = context;
    }
    public async Task<IEnumerable<Comment>> GetAll()
    {
       return await _sqlDataContext.Comments.ToListAsync();
    }

    public async Task Add(Comment entity)
    {
        await _sqlDataContext.Comments.AddAsync(entity);
    }

    public async Task Delete(int id)
    {
        var commentToDelete = await GetById(id);
        _sqlDataContext.Comments.Remove(commentToDelete);
        await _sqlDataContext.SaveChangesAsync();
    }

    public async Task<Comment> GetById(int id)
    {
       return await _sqlDataContext.Comments.FindAsync(id);
    }

    public async Task Update(int id, Comment entity)
    {
        var commentToUpdate = await GetById(id);
        _sqlDataContext.Comments.Update(commentToUpdate);
        await _sqlDataContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Comment>> CommentsByBlogPost(int blogPostId)
    {
        var blogpost = await _sqlDataContext.BlogPosts.FindAsync(blogPostId);
        return blogpost.Comments;

    }
}
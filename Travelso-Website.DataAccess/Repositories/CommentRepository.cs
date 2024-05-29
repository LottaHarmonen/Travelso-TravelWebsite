using Microsoft.EntityFrameworkCore;
using Travelso_Website_Shared.Entities;
using Travelso_Website_Shared.Interfaces.IService;

namespace Travelso_Website.DataAccess.Repositories;

public class CommentRepository(TravelsoSQLDataContext context) : ICommentService
{
    public async Task<IEnumerable<Comment>> GetAll()
    {
       return await context.Comments.ToListAsync();
    }

    public async Task<bool> Add(Comment entity)
    {
        await context.Comments.AddAsync(entity);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var commentToDelete = await GetById(id);
        if (commentToDelete is null)
        {
            return false;
        }
        context.Comments.Remove(commentToDelete);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<Comment> GetById(int id)
    {
       return await context.Comments.FindAsync(id);
    }

    public async Task<bool> Update(int id, Comment entity)
    {
        var commentToUpdate = await GetById(id);
        if (commentToUpdate is null)
        {
            return false;
        }
        context.Comments.Update(commentToUpdate);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Comment>?>? CommentsByBlogPost(int blogPostId)
    {
        var blogpost = await context.BlogPosts.FindAsync(blogPostId);
        if (blogpost is null)
        {
            return null;
        }

        //get all comments with that id
        var comments = context.Comments.Where(c => c.BlogPostId == blogPostId);

        return comments;

    }
}
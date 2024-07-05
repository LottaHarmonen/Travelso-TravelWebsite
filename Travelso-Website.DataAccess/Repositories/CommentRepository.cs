using Microsoft.EntityFrameworkCore;
using Travelso_Website_Shared.Entities;
using Travelso_Website_Shared.Interfaces.IRepository;
using Travelso_Website_Shared.Interfaces.IService;

namespace Travelso_Website.DataAccess.Repositories;

public class CommentRepository(TravelsoSQLDataContext context) : ICommentRepository
{
    public async Task<Comment?> GetById(object? id)
    {
        return (await context.Comments.FindAsync(id))!;
    }

    public async Task<IEnumerable<Comment>?> GetAll()
    {
       return (await context.Comments.ToListAsync())!;
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

        return comments!;

    }

    public async Task<bool> Add(Comment entity)
    {
        await context.Comments.AddAsync(entity);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Update(Comment entity)
    {
        var commentToUpdate = await GetById(entity.BlogPostId);
        if (commentToUpdate is null)
        {
            return false;
        }
        context.Comments.Update(commentToUpdate);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(object? id)
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
}
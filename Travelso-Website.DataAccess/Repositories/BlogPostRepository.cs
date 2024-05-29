using Microsoft.EntityFrameworkCore;
using Travelso_Website_Shared.Entities;
using Travelso_Website_Shared.Interfaces.IService;

namespace Travelso_Website.DataAccess.Repositories;

public class BlogPostRepository : IBlogPostService
{
    private readonly TravelsoSQLDataContext _sqlDataContext;

    public BlogPostRepository(TravelsoSQLDataContext context)
    {
        _sqlDataContext = context;
    }

    public async Task<IEnumerable<BlogPost>> GetAll()
    {
        return await _sqlDataContext.BlogPosts.ToListAsync();
    }

    public async Task<bool> Add(BlogPost entity)
    {
        await _sqlDataContext.BlogPosts.AddAsync(entity);
        await _sqlDataContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var blogPostToDelete = await GetById(id);
        if (blogPostToDelete == null)
        {
            return false;
        }

        _sqlDataContext.BlogPosts.Remove(blogPostToDelete);
        await _sqlDataContext.SaveChangesAsync();
        return true;
    }


    public async Task<BlogPost?> GetById(int id)
    {
        return await _sqlDataContext.BlogPosts.FindAsync(id);
    }

    public async Task<bool> Update(int id, BlogPost entity)
    {
        var blogPostToUpdate = await GetById(id);
        if (blogPostToUpdate == null)
        {
            return false;
        }

        _sqlDataContext.BlogPosts.Update(blogPostToUpdate);
        await _sqlDataContext.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<BlogPost>?> GetPostsByCountryAsync(int countryId)
    {
        return _sqlDataContext.BlogPosts.Where(b => b.CountryId == countryId);
    }

    public async Task<IEnumerable<BlogPost>> PostsByUserAsync(string userId)
    {
        var user = await _sqlDataContext.TravelsoUsers.FindAsync(userId);
        return _sqlDataContext.BlogPosts.Where(b => b.TravelsoUser == userId);
    }
}
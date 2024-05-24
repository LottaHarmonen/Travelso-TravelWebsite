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

    public async Task Add(BlogPost entity)
    {
        await _sqlDataContext.BlogPosts.AddAsync(entity);
        await _sqlDataContext.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var BlogPostToDelete = await GetById(id);
        if (BlogPostToDelete == null)
        {

        }

        _sqlDataContext.BlogPosts.Remove(BlogPostToDelete);
        await _sqlDataContext.SaveChangesAsync();
    }

    public async Task<BlogPost> GetById(int id)
    {
        return await _sqlDataContext.BlogPosts.FindAsync(id);
    }

    public async Task Update(int id, BlogPost entity)
    {
        var BlogPostToUpdate = await GetById(id);
        if (BlogPostToUpdate == null)
        {

        }

        _sqlDataContext.BlogPosts.Update(BlogPostToUpdate);
        await _sqlDataContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<BlogPost>> GetPostsByCountryAsync(int countryId)
    {
        return _sqlDataContext.BlogPosts.Where(b => b.CountryId == countryId);

    }

    public async Task<IEnumerable<BlogPost>> PostsByUserAsync(string userId)
    {
        var user = await _sqlDataContext.TravelsoUsers.FindAsync(userId);
        return _sqlDataContext.BlogPosts.Where(b => b.TravelsoUser.UserId == userId);
    }
}
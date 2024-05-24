using Travelso_Website_Shared.Entities;
using Travelso_Website_Shared.Interfaces.IService;

namespace Travelso_TravelWebsite.Services;

public class BlogPostService : IBlogPostService
{
    private readonly HttpClient _httpClient;

    public BlogPostService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("");
    }

    public Task<IEnumerable<BlogPost>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task Add(BlogPost entity)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<BlogPost> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Update(int id, BlogPost entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<BlogPost>> GetPostsByCountryAsync(int countryId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<BlogPost>> PostByUserAsync(int userId)
    {
        throw new NotImplementedException();
    }
}
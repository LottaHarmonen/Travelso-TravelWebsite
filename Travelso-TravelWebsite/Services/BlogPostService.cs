using Travelso_Website_Shared.Entities;
using Travelso_Website_Shared.Interfaces.IService;

namespace Travelso_TravelWebsite.Services;

public class BlogPostService : IBlogPostService
{
    private readonly HttpClient _httpClient;

    public BlogPostService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("Travelso-Api");
    }

    public async Task<IEnumerable<BlogPost>?> GetAll()
    {
        var response = await _httpClient.GetAsync("/blogpost");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<BlogPost[]>();
        }

        return null;

    }

    public async Task<bool> Add(BlogPost entity)
    {
        var response = await _httpClient.PostAsJsonAsync("/blogPost", entity);
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        return false;
    }

    public async Task<bool> Delete(int id)
    {
        var response = await _httpClient.DeleteAsync($"/blogpost/blogPostId/{id}");
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        return false;
    }

    public async Task<BlogPost?> GetById(int id)
    {
        var response = await _httpClient.GetAsync($"/blogPost/blogPostId/{id}");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<BlogPost>();
        }
        return null;
    }

    public async Task<bool> Update(int id, BlogPost entity)
    {
        var response = await _httpClient.PutAsJsonAsync($"/blogPost/blogPostId/{id}", entity);
        if (response.IsSuccessStatusCode)
        {
            return true;
        }

        return false;
    }

    public async Task<IEnumerable<BlogPost>?> GetPostsByCountryAsync(int countryId)
    {
        var response = await _httpClient.GetAsync($"/blogpost/countryId/{countryId}");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<BlogPost[]>();
        }
        return null;
    }

    public async Task<IEnumerable<BlogPost>?> PostsByUserAsync(string? userId)
    {
        var response = await _httpClient.GetAsync($"/blogpost/userId/{userId}");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<BlogPost[]>();
        }

        return null;
    }


}
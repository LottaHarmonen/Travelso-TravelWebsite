using System.Reflection.Metadata.Ecma335;
using Travelso_Website_Shared.Entities;
using Travelso_Website_Shared.Interfaces.IService;

namespace Travelso_TravelWebsite.Services;

public class CommentService(IHttpClientFactory factory) : ICommentService
{
    private readonly HttpClient _httpClient = factory.CreateClient("Travelso-Api");


    public async Task<IEnumerable<Comment>?> GetAll()
    {
        var response = await _httpClient.GetAsync($"/comment");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<Comment[]>();
        }

        return null;
    }

    public async Task<bool> Add(Comment entity)
    {
        var response = await _httpClient.PostAsJsonAsync("/comment", entity);
        if (response.IsSuccessStatusCode)
        {
            return true;
        }

        return false;
    }

    public async Task<bool> Delete(int id)
    {
        var response = await _httpClient.DeleteAsync($"/comment/commentId/{id}");
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        return false;
    }

    public async Task<Comment>? GetById(int id)
    {
        var response = await _httpClient.GetAsync($"/comment/commentId/{id}");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<Comment>();
        }

        return null;

    }

    public async Task<bool> Update(int id, Comment entity)
    {
        var response = await _httpClient.PutAsJsonAsync($"/comment/commentId/{id}", entity);
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        return false;
    }


    public async Task<IEnumerable<Comment>?>? CommentsByBlogPost(int blogPostId)
    {
        var response = await _httpClient.GetAsync($"/comment/blogPostId/{blogPostId}");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<Comment[]>();
        }

        return null;
    }
}
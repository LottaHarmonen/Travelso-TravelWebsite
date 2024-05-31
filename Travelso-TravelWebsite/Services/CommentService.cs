using System.Reflection.Metadata.Ecma335;
using Travelso_Website_Shared.DTOs.UserDTOs;
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


    public async Task<List<UserCommentDTO>?>? CommentsByBlogPost(int blogPostId)
    {
        var response = await _httpClient.GetAsync($"/comment/blogPostId/{blogPostId}");
        var listOfUserCommentDTOs = new List<UserCommentDTO>();

        if (response.IsSuccessStatusCode)
        {
            var comments = await response.Content.ReadFromJsonAsync<Comment[]>();

            foreach (var comment in comments)
            {
                //get the user details 
                var userResponse = await _httpClient.GetAsync($"users/{comment.TravelsoUser}");
                if (userResponse.IsSuccessStatusCode)
                {
                    var user = await response.Content.ReadFromJsonAsync<TravelsoUser>();
                    var commentUser = new UserCommentDTO()
                    {
                        BlogPostId = comment.BlogPostId,
                        comment = comment.comment,
                        CommentId = comment.CommentId,
                        publicationDate = comment.publicationDate,
                        userImageURL = user.ProfileImage,
                        username = user.UserName
                    };
                    listOfUserCommentDTOs.Add(commentUser);
                }
            }

            return listOfUserCommentDTOs;
        }

        return null;
    }
}
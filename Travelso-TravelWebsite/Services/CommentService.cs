using Travelso_Website_Shared.Entities;
using Travelso_Website_Shared.Interfaces.IService;

namespace Travelso_TravelWebsite.Services;

public class CommentService : ICommentService
{
    private readonly HttpClient _httpClient;

    public CommentService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("");
    }


    public Task<IEnumerable<Comment>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task Add(Comment entity)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Comment> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Update(int id, Comment entity)
    {
        throw new NotImplementedException();
    }


    public Task<IEnumerable<Comment>> CommentsByBlogPost(int blogPostId)
    {
        throw new NotImplementedException();
    }
}
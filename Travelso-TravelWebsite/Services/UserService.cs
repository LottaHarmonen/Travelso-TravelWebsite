using System.Net.Http;
using Travelso_Website_Shared.Entities;
using Travelso_Website_Shared.Interfaces.IService;

namespace Travelso_TravelWebsite.Services;
public class UserService : IUserService
{
    private readonly HttpClient _httpClient;

    public UserService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("");
    }


    public async Task<IEnumerable<TravelsoUser>> GetAll()
    {
        var response = await _httpClient.GetAsync("/users");

        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException("Failed to retrieve users");
        }

        var users = await response.Content.ReadFromJsonAsync<List<TravelsoUser>>();
        return users;
    }

    public async Task Add(TravelsoUser entity)
    {
        await _httpClient.PostAsJsonAsync("/users/", entity);
    }

    public async Task Delete(int id)
    {
        await _httpClient.DeleteAsync("/users");
    }

    public async Task<TravelsoUser> GetById(int id)
    {
        return await _httpClient.GetFromJsonAsync<TravelsoUser>($"users/userId/{id}");
    }

    public async Task Update(int id, TravelsoUser entity)
    {
        await _httpClient.PostAsJsonAsync("/users/", entity);
    }
}
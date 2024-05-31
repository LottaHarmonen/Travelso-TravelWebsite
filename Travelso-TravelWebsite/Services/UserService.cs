using System.Net.Http;
using System.Threading.Tasks.Sources;
using Travelso_Website_Shared.DTOs.UserDTOs;
using Travelso_Website_Shared.Entities;
using Travelso_Website_Shared.Interfaces.IService;

namespace Travelso_TravelWebsite.Services;
public class UserService(IHttpClientFactory factory) : IUserService
{
    private readonly HttpClient _httpClient = factory.CreateClient("Travelso-Api");

    //TODO NAME


    public async Task<IEnumerable<TravelsoUser>> GetAll()
    {
        var response = await _httpClient.GetAsync("/users");

        if (response.IsSuccessStatusCode)
        {
            var users = await response.Content.ReadFromJsonAsync<List<TravelsoUser>>();
            return users;
        }

        return null;

    }

    public async Task<TravelsoUser>? GetUserByMail(string userMail)
    {
        var response = await _httpClient.GetAsync($"/users/userMail/{userMail}");
        if (response.IsSuccessStatusCode)
        {
            var travelsoUser = await response.Content.ReadFromJsonAsync<TravelsoUser>();
            return travelsoUser;
        }

        return null;
    }

    public async Task<bool> Add(NewUserDTO entity)
    {
       var response = await _httpClient.PostAsJsonAsync("/users/", entity);
       if (response.IsSuccessStatusCode)
       {
           return true;
       }

       return false;
    }



    public async Task<bool> UpdateUserWithId(string userId, TravelsoUser user)
    {
        var response = await _httpClient.PostAsJsonAsync("/users/", user);
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        return false;
    }

    public async Task<TravelsoUser> GetUserWithId(string userId)
    {

        var user = await _httpClient.GetFromJsonAsync<TravelsoUser>($"users/{userId}");
        if (user is null)
        {
            return user;
        }

        return null;
    }

    public async Task<bool> DeleteUserWithId(string userId)
    {
        var response = await _httpClient.DeleteAsync($"/users/{userId}");
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        return false;
    }
}
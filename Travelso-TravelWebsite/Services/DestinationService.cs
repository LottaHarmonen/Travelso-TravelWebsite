using Travelso_Website_Shared.Entities;
using Travelso_Website_Shared.Interfaces.IService;

namespace Travelso_TravelWebsite.Services;

public class DestinationService(IHttpClientFactory factory) : IDestinationService
{
    private readonly HttpClient _httpClient = factory.CreateClient("Travelso-Api");

    public async Task<IEnumerable<Destination>?> GetAll()
    {
        var response = await _httpClient.GetAsync($"/destination");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<Destination[]>();
        }

        return null;

    }

    public async Task<bool> Add(Destination entity)
    {
       var response = await _httpClient.PostAsJsonAsync($"/destination", entity);
       if (response.IsSuccessStatusCode)
       {
           return true;
       }
       return false;

    }

    public async Task<bool> Delete(int id)
    {
      var response = await _httpClient.DeleteAsync($"/destination/destinationId/{id}");
      if (response.IsSuccessStatusCode)
      {
          return true;
      }
      return false;
    }

    public async Task<Destination> GetById(int id)
    {
       var response = await _httpClient.GetAsync($"/destination/destinationId/{id}");

       if (response.IsSuccessStatusCode)
       {
           return await response.Content.ReadFromJsonAsync<Destination>();
       }
        
       return null;

    }

    public async Task<bool> Update(int id, Destination entity)
    {
        var response = await _httpClient.PutAsJsonAsync($"/destination/destination/{id}", entity);
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        return false;
    }
}
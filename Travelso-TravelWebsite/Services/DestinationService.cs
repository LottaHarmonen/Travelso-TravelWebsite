using Travelso_Website_Shared.Entities;
using Travelso_Website_Shared.Interfaces.IService;

namespace Travelso_TravelWebsite.Services;

public class DestinationService : IDestinationService
{
    private readonly HttpClient _httpClient;

    public DestinationService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("");
    }

    public async Task<IEnumerable<Destination>> GetAll()
    {
        var response = await _httpClient.GetAsync("/destination");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<List<Destination>>();
        }
        throw new ApplicationException("Failed to retrieve users");

    }

    public async Task Add(Destination entity)
    {
        await _httpClient.PostAsJsonAsync("/destination", entity);
    }

    public async Task Delete(int id)
    {
        await _httpClient.DeleteAsync($"/destination/{id}");
    }

    public async Task<Destination> GetById(int id)
    {
       var response = await _httpClient.GetAsync($"/destination/{id}");

       if (response.IsSuccessStatusCode)
       {
           return await response.Content.ReadFromJsonAsync<Destination>();
       }

       throw new ApplicationException("Failed to retrieve users");

    }

    public Task Update(int id, Destination entity)
    {
        throw new NotImplementedException();
    }
}
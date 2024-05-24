using System.Net.Http;
using Travelso_Website_Shared.Entities;
using Travelso_Website_Shared.Interfaces.IService;

namespace Travelso_TravelWebsite.Services;

public class CountryService : ICountryService
{
    private readonly HttpClient _httpClient;

    public CountryService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("");
    }


    public Task<IEnumerable<Country>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task Add(Country entity)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Country> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Update(int id, Country entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Country>> GetCountriesByUserAsync(string UserId)
    {
        throw new NotImplementedException();
    }

}
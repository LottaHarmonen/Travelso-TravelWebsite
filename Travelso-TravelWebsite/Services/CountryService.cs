using Azure;
using System.Net.Http;
using Travelso_Website_Shared.Entities;
using Travelso_Website_Shared.Interfaces.IService;

namespace Travelso_TravelWebsite.Services;

public class CountryService(IHttpClientFactory factory) : ICountryService
{
    private readonly HttpClient _httpClient = factory.CreateClient("Travelso-Api");


    public async Task<IEnumerable<Country>?> GetAll()
    {
        var response = await _httpClient.GetAsync($"/country");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<Country[]>();
            
        }
        return Enumerable.Empty<Country>();
    }

    public async Task<bool> Add(Country entity)
    { 
       var response = await _httpClient.PostAsJsonAsync("/country", entity);
       if (response.IsSuccessStatusCode)
       {
           return true;
       }

       return false;
    }

    public async Task<bool> Delete(int id)
    {
        var response = await _httpClient.DeleteAsync($"country/CountryId/{id}");
        if (response.IsSuccessStatusCode)
        {
            return true;
        }

        return false;
    }

    public async Task<Country?> GetById(int id)
    {
        var response = await _httpClient.GetAsync($"country/CountryId/{id}");

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<Country>();
        }

        return null;

    }

    public async Task<bool> Update(int id, Country entity)
    {
        var response = await _httpClient.PutAsJsonAsync($"/country/CountryId/{id}", entity);
        if (response.IsSuccessStatusCode)
        {
            return true;
        }

        return false;
    }

    public async Task<IEnumerable<Country>?> GetCountriesByUserAsync(string userId)
    {
        var response = await _httpClient.GetAsync($"/country/Userid/{userId}");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<Country[]>();
        }

        return null;
    }

}
using Travelso_Website.DataAccess.Repositories;
using Travelso_Website_Shared.Entities;

namespace Travlso_Website.API.Extensions;

public static class CountryEndpointExtension
{
    public static IEndpointRouteBuilder CountryEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/country");

        group.MapGet("/", GetAllCountries);
        group.MapGet("/Userid/{UserId}", GetCountriesByUser);
        group.MapGet("/CountryId/{countryId}", GetCountryById);
        group.MapPost("/", AddCountry);
        group.MapPut("/CountryId/{countryId}", UpdateCountry);
        group.MapDelete("/countryId/{countryId}", DeleteCountry);

        return app;
    }

    private static async Task<Country> GetCountryById(CountryRepository repo, int countryId)
    {
        var country = await repo.GetById(countryId);
        if (country is null)
        {
            Results.NotFound($"No country found with the given id {countryId}");
        }
        Results.Ok();
        return country;

    }

    private static async Task DeleteCountry(CountryRepository repo, int countryId)
    {
        var isCountryDeleted = await repo.Delete(countryId);
        if (isCountryDeleted)
        {
            Results.Ok();
        }

        Results.BadRequest();

    }

    private static async Task UpdateCountry(CountryRepository repo, int countryId, Country country)
    {
        var countryToUpdate = await repo.GetById(countryId);
        if (countryToUpdate is null)
        {
            Results.NotFound($"No Country found with the given id {countryId}");
        }
        else
        {

            var isCountryUpdated = await repo.Update(countryId, country);
            if (isCountryUpdated)
            {
                Results.Ok();
            }
            Results.NotFound($"No Country found with the given id {countryId}");
        }

    }

    private static async Task AddCountry(CountryRepository repo, Country country)
    {
        var isCountryAdded = await repo.Add(country);
        if (isCountryAdded)
        {
            Results.Ok();
        }

        Results.BadRequest();
    }

    private static async Task<IEnumerable<Country>?> GetCountriesByUser(CountryRepository repo, string userId)
    {
        var countries = await repo.GetCountriesByUserAsync(userId);
        if (countries is null)
        {
            Results.NotFound($"No countries found with the given user Id {userId}");
        }

        Results.Ok(countries);
        return countries;
    }

    private static async Task<IEnumerable<Country>> GetAllCountries(CountryRepository repo)
    {
        var countries = await repo.GetAll();
        if (countries is null)
        {
            Results.NotFound();
        }

        Results.Ok();
        return countries;
    }
}
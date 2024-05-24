using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Travelso_Website_Shared.Entities;
using Travelso_Website_Shared.Interfaces.IService;

namespace Travelso_Website.DataAccess.Repositories;

public class CountryRepository : ICountryService
{
    private readonly TravelsoSQLDataContext _sqlDataContext;
    

    public CountryRepository(TravelsoSQLDataContext context)
    {
        _sqlDataContext = context;
    }

    public List<Country> Countries { get; set; } = new List<Country>
    {
        new Country { Name = "Portugal", ImageURL = "https://example.com/flags/portugal.png" },
        new Country { Name = "Spain", ImageURL = "https://example.com/flags/spain.png" },
        new Country { Name = "France", ImageURL = "https://example.com/flags/france.png" },
    };

    public async Task<IEnumerable<Country>> GetAll()
    {
        return await _sqlDataContext.Countries.ToListAsync();
    }

    public async Task Add(Country entity)
    {
        await _sqlDataContext.Countries.AddAsync(entity);
        await _sqlDataContext.SaveChangesAsync();

    }

    public async Task Delete(int id)
    {
        var countryToDelete = await GetById(id);
        if (countryToDelete is null)
        {

        }

        _sqlDataContext.Countries.Remove(countryToDelete);
        await _sqlDataContext.SaveChangesAsync();
    }

    public async Task<Country> GetById(int id)
    {
        return await _sqlDataContext.Countries.FindAsync(id);
    }

    public async Task Update(int id, Country entity)
    {
        var countryToUpdate = await GetById(id);
        if (countryToUpdate is null)
        {

        }

        _sqlDataContext.Countries.Update(countryToUpdate);
        await _sqlDataContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Country>> GetCountriesByUserAsync(string UserId)
    {
        var user = await _sqlDataContext.TravelsoUsers
            .Include(u => u.MyVisitedCountries)
            .FirstOrDefaultAsync(u => u.UserId == UserId);

        return user.MyVisitedCountries.ToList();

    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Travelso_Website_Shared.Entities;
using Travelso_Website_Shared.Interfaces.IRepository;
using Travelso_Website_Shared.Interfaces.IService;

namespace Travelso_Website.DataAccess.Repositories;

public class CountryRepository(TravelsoSQLDataContext context) : ICountryRepository
{
    public async Task<IEnumerable<Country>?> GetAll()
    {
        return await context.Countries.ToListAsync();
    }

    public async Task<Country?> GetById(object? id)
    {
        return await context.Countries.FindAsync(id);
    }

    public async Task<IEnumerable<Country>?> GetCountriesByUserAsync(string userId)
    {
        var user = await context.TravelsoUsers
            .Include(u => u.MyVisitedCountries)
            .FirstOrDefaultAsync(u => u.UserId == userId);

        List<Country> list = [];
        foreach (var country in user!.MyVisitedCountries) list.Add(country);
        return list;

    }

    public async Task<bool> Add(Country entity)
    {
        await context.Countries.AddAsync(entity);
        await context.SaveChangesAsync();
        return true;

    }


    public async Task<bool> Update(Country entity)
    {
        var countryToUpdate = await GetById(entity.CountryId);
        if (countryToUpdate is null)
        {
            return false;
        }

        context.Countries.Update(countryToUpdate);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(object? id)
    {
        var countryToDelete = await GetById(id);
        if (countryToDelete is null)
        {
            return false;
        }

        context.Countries.Remove(countryToDelete);
        await context.SaveChangesAsync();
        return true;
    }
}
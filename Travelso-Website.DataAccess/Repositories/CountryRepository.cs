using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Travelso_Website_Shared.Entities;
using Travelso_Website_Shared.Interfaces.IService;

namespace Travelso_Website.DataAccess.Repositories;

public class CountryRepository(TravelsoSQLDataContext context) 
{
    public async Task<IEnumerable<Country>>? GetAll()
    {
        return await context.Countries.ToListAsync();
    }

    public async Task<bool> Add(Country entity)
    {
        await context.Countries.AddAsync(entity);
        await context.SaveChangesAsync();
        return true;

    }

    public async Task<bool> Delete(int id)
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

    public async Task<Country>? GetById(int id)
    {
        return await context.Countries.FindAsync(id);
    }

    public async Task<bool> Update(int id, Country entity)
    {
        var countryToUpdate = await GetById(id);
        if (countryToUpdate is null)
        {
            return false;
        }

        context.Countries.Update(countryToUpdate);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Country>>? GetCountriesByUserAsync(string UserId)
    {
        var user = await context.TravelsoUsers
            .Include(u => u.MyVisitedCountries)
            .FirstOrDefaultAsync(u => u.UserId == UserId);

        return user.MyVisitedCountries.ToList();

    }
}
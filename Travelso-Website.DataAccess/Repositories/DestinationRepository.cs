using Microsoft.EntityFrameworkCore;
using Travelso_Website_Shared.Entities;
using Travelso_Website_Shared.Interfaces.IService;

namespace Travelso_Website.DataAccess.Repositories;

public class DestinationRepository(TravelsoSQLDataContext context) : IDestinationService
{
    public async Task<IEnumerable<Destination>?> GetAll()
    {
        return await context.Destinations.ToListAsync();
    }

    public async Task<bool> Add(Destination entity)
    {
        await context.Destinations.AddAsync(entity);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var destination = await GetById(id);
        if (destination == null)
        {
            return false;
        }

        context.Destinations.Remove(destination);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<Destination> GetById(int id)
    {
        return await context.Destinations.FindAsync(id);
    }

    public async Task<bool> Update(int id, Destination entity)
    {
        var destinationToUpdate = await GetById(id);
        if (destinationToUpdate == null)
        {
            return false;
        }

        context.Destinations.Update(entity);
        await context.SaveChangesAsync();
        return true;
    }


}
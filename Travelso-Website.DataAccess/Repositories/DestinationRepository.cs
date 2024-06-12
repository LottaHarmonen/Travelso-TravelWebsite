using Microsoft.EntityFrameworkCore;
using Travelso_Website_Shared.Entities;
using Travelso_Website_Shared.Interfaces.IRepository;
using Travelso_Website_Shared.Interfaces.IService;

namespace Travelso_Website.DataAccess.Repositories;

public class DestinationRepository(TravelsoSQLDataContext context) : IDestinationRepository
{

    public async Task<IEnumerable<Destination>?> GetAll()
    {
        return await context.Destinations.ToListAsync();
    }

    public async Task<Destination> GetById(object id)
    {
        return await context.Destinations.FindAsync(id);
    }

    public async Task<bool> Add(Destination entity)
    {
        await context.Destinations.AddAsync(entity);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Update(Destination entity)
    {
        var destinationToUpdate = await GetById(entity.DestinationId);
        if (destinationToUpdate == null)
        {
            return false;
        }

        context.Destinations.Update(entity);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(object id)
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













}
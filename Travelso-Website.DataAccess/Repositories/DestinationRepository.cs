using Microsoft.EntityFrameworkCore;
using Travelso_Website_Shared.Entities;
using Travelso_Website_Shared.Interfaces.IService;

namespace Travelso_Website.DataAccess.Repositories;

public class DestinationRepository : IDestinationService
{
    private readonly TravelsoSQLDataContext _sqlDataContext;

    public DestinationRepository(TravelsoSQLDataContext context)
    {
        _sqlDataContext = context;
    }
    public async Task<IEnumerable<Destination>> GetAll()
    {
        return await _sqlDataContext.Destinations.ToListAsync();
    }

    public async Task Add(Destination entity)
    {
        await _sqlDataContext.Destinations.AddAsync(entity);
        await _sqlDataContext.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var destination = await GetById(id);
        if (destination == null)
        {

        }

        _sqlDataContext.Destinations.Remove(destination);
        await _sqlDataContext.SaveChangesAsync();
    }

    public async Task<Destination> GetById(int id)
    {
        return await _sqlDataContext.Destinations.FindAsync(id);
    }

    public async Task Update(int id, Destination entity)
    {
        var destinationToUpdate = await GetById(id);
        if (destinationToUpdate == null)
        {

        }

        _sqlDataContext.Destinations.Update(entity);
        await _sqlDataContext.SaveChangesAsync();
    }
}
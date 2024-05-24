using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Travelso_Website_Shared.Entities;
using Travelso_Website_Shared.Interfaces.IService;

namespace Travelso_Website.DataAccess.Repositories;

public class UserRepository : IUserService
{
    private readonly TravelsoSQLDataContext _sqlDataContext;

    public UserRepository(TravelsoSQLDataContext context)
    {
        _sqlDataContext = context;
    }

    public async Task<IEnumerable<TravelsoUser>> GetAll()
    {
      return await _sqlDataContext.TravelsoUsers.ToListAsync();
    }

    public async Task Add(TravelsoUser entity)
    {
        await _sqlDataContext.TravelsoUsers.AddAsync(entity);
    }

    public async Task Delete(int id)
    {
        var user = await GetById(id);
        if (user == null)
        {
            
        }
        _sqlDataContext.TravelsoUsers.Remove(user);
        await _sqlDataContext.SaveChangesAsync();
    }

    public async Task<TravelsoUser> GetById(int id)
    {
        return await _sqlDataContext.TravelsoUsers.FindAsync(id);
    }

    public async Task Update(int id, TravelsoUser entity)
    {
        var user = await GetById(id);
        if (user is null)
        {
            return;
        }

        _sqlDataContext.TravelsoUsers.Update(user);
        await _sqlDataContext.SaveChangesAsync();



    }
}
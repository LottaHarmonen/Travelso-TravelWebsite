using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Travelso_Website_Shared.Entities;
using Travelso_Website_Shared.Interfaces.IRepository;
using Travelso_Website_Shared.Interfaces.IService;

namespace Travelso_Website.DataAccess.Repositories;

public class UserRepository(TravelsoSQLDataContext context) : IUserRepository
{

    public async Task<bool> Add(TravelsoUser entity)
    {
        await context.TravelsoUsers.AddAsync(entity);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Update(TravelsoUser entity)
    {
        var travelsoUser = await GetById(entity.UserId);
        if (travelsoUser is null)
        {
            return false;
        }
        context.Entry(travelsoUser).CurrentValues.SetValues(entity);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(object? id)
    {
        var user = await GetById(id);
        if (user == null)
        {
            return false;
        }
        context.TravelsoUsers.Remove(user);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<TravelsoUser?> GetById(object? id)
    {
        var user = await context.TravelsoUsers.FirstOrDefaultAsync(u => u.UserId == id);
        return user;
    }

    public async Task<IEnumerable<TravelsoUser>?> GetAll()
    {
      return await context.TravelsoUsers.ToListAsync();
    }

    public async Task<TravelsoUser> GetByMail(string email)
    {
        var travelsoUser = await context.TravelsoUsers.FirstOrDefaultAsync(u => u.Email == email);
        if (travelsoUser == null)
        {
            return null;
        }
        return travelsoUser;
    }



}
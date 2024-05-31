using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Travelso_Website_Shared.Entities;
using Travelso_Website_Shared.Interfaces.IService;

namespace Travelso_Website.DataAccess.Repositories;

public class UserRepository(TravelsoSQLDataContext context) : IUserService
{
    public async Task<IEnumerable<TravelsoUser>> GetAll()
    {
      return await context.TravelsoUsers.ToListAsync();
    }

    public async Task<TravelsoUser> GetUserByMail(string userMail)
    {
        var travelsoUser = await context.TravelsoUsers.FirstOrDefaultAsync(u => u.Email == userMail);
        if (travelsoUser == null)
        {
            return null;
        }
        return travelsoUser;
    }

    public async Task<bool> Add(TravelsoUser entity)
    {
      await context.TravelsoUsers.AddAsync(entity);
      await context.SaveChangesAsync();
      return true;
    }

    public async Task<bool> UpdateUserWithId(string userId, TravelsoUser user)
    {
        var travelsoUser = await GetUserWithId(userId);
        if (travelsoUser is null)
        {
            return false;
        }
        context.TravelsoUsers.Update(user);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<TravelsoUser>? GetUserWithId(string userId)
    {
        var user = await context.TravelsoUsers.FirstOrDefaultAsync(u => u.UserId == userId);
        return user;
    }

    public async Task<bool> DeleteUserWithId(string userId)
    {
        var user = await GetUserWithId(userId);
        if (user == null)
        {
            return false;
        }
        context.TravelsoUsers.Remove(user);
        await context.SaveChangesAsync();
        return true;
    }
}
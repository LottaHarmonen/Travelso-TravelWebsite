using Travelso_Website_Shared.Entities;

namespace Travelso_Website_Shared.Interfaces.IService;

public interface IUserService 
{
    public Task<bool> UpdateUserWithId(string userId, TravelsoUser user);
    public Task<TravelsoUser> GetUserWithId(string userId);
    public Task<bool> DeleteUserWithId(string userId);

}
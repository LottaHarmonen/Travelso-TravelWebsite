using Travelso_Website_Shared.Entities;

namespace Travelso_Website_Shared.Interfaces.IRepository;

public interface IUserRepository : IRepository<TravelsoUser>
{
    public Task<TravelsoUser> GetByMail(string email);
}
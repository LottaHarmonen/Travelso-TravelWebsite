using Travelso_Website_Shared.Entities;

namespace Travelso_Website_Shared.Interfaces.IRepository;

public interface ICountryRepository : IRepository<Country>
{
    Task<IEnumerable<Country>> GetCountriesByUserAsync(string UserId);
}
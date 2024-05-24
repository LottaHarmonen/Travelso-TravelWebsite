using Travelso_Website_Shared.Entities;

namespace Travelso_Website_Shared.Interfaces.IService;

public interface ICountryService : IGenericService<Country>
{
    Task<IEnumerable<Country>> GetCountriesByUserAsync(string UserId);
}
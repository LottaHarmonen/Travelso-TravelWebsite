using Travelso_Website_Shared.Entities;

namespace Travelso_Website_Shared.Interfaces.IRepository;

public interface IBlogpostRepository : IRepository<BlogPost>
{

    Task<IEnumerable<BlogPost>?> GetPostsByCountryAsync (int countryId);

    Task<IEnumerable<BlogPost>?> PostsByUserAsync(string userId);

}
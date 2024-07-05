using Travelso_Website_Shared.Entities;

namespace Travelso_Website_Shared.Interfaces.IService;

public interface IBlogPostService : IGenericService<BlogPost>
{
    Task<IEnumerable<BlogPost>?> GetPostsByCountryAsync(int countryId);
    Task<IEnumerable<BlogPost>?> PostsByUserAsync(string? userId);
}
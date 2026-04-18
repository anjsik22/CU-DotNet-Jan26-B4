using NorthWindCatalog.Services.Models;

namespace NorthWindCatalog.Services.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
    }
}

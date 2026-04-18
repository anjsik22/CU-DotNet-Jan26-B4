using NorthWindCatalog.Services.DTOs;
using NorthWindCatalog.Services.Models;

namespace NorthWindCatalog.Services.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetByCategoryIdAsync(int categoryId);
        Task<IEnumerable<CategorySummaryDto>> GetCategorySummariesAsync();
    }
}

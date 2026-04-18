using Microsoft.EntityFrameworkCore;
using NorthWindCatalog.Services.Data;
using NorthWindCatalog.Services.Models;

namespace NorthWindCatalog.Services.Repositories
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly NorthWindContext _context;

        public CategoryRepository(NorthWindContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}

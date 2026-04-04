using Microsoft.EntityFrameworkCore;
using Travel.BackEnd.Data;
using Travel.BackEnd.Exceptions;
using Travel.BackEnd.Models;

namespace Travel.BackEnd.Repository
{
    public class DestinationRepository : IDestinationRepository
    {
        private readonly AppDbContext _context;

        public DestinationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Destination>> GetAllAsync()
        {
            return await _context.Destinations.ToListAsync();
        }

        public async Task<Destination?> GetByIdAsync(int id)
        {
            return await _context.Destinations.FindAsync(id);
        }

        public async Task AddAsync(Destination destination)
        {
            await _context.Destinations.AddAsync(destination);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Destination destination)
        {
            _context.Destinations.Update(destination);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var dest = await _context.Destinations.FindAsync(id);
            if (dest == null)
                throw new DestinationNotFoundException($"Destination with ID {id} not found");

            _context.Destinations.Remove(dest);
            await _context.SaveChangesAsync();
        }
    }
}

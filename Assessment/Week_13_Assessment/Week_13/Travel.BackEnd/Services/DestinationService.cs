using Travel.BackEnd.DTOs;
using Travel.BackEnd.Exceptions;
using Travel.BackEnd.Models;
using Travel.BackEnd.Repository;

namespace Travel.BackEnd.Services
{
    public class DestinationService: IDestinationService
    {
        private readonly IDestinationRepository _repository;

        public DestinationService(IDestinationRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Destination>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Destination> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Destination destination)
        {
            if (destination.Rating <= 0)
            {
                destination.Rating = 3;
            }
            if (destination.Rating > 5)
                throw new Exception("Rating must be between 1 and 5");

            await _repository.AddAsync(destination);
        }

        public async Task UpdateAsync(Destination destination)
        {
            await _repository.UpdateAsync(destination);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}

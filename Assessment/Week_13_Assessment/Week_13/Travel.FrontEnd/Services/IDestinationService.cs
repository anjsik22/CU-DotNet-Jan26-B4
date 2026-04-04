using Travel.FrontEnd.Models;

namespace Travel.FrontEnd.Services
{
    public interface IDestinationService
    {
        Task<List<Destination>> GetAllAsync();
        Task CreateAsync(Destination destination);
        Task UpdateAsync(Destination destination);  
        Task DeleteAsync(int id);

    }
}

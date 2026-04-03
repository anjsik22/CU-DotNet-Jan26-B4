using MongoDB.Driver;
using RazorMongo.Models;

namespace RazorMongo.Services
{
    public class LaptopService
    {
        private readonly IMongoCollection<Laptop> _laptops;

        public LaptopService(IConfiguration config)
        {
            var client = new MongoClient(config["MongoDbSettings:ConnectionString"]);
            var database = client.GetDatabase(config["MongoDbSettings:DatabaseName"]);
            _laptops = database.GetCollection<Laptop>(config["MongoDbSettings:FeedbackCollection"]);
        }

        public async Task<List<Laptop>> GetAsync() =>
            await _laptops.Find(_ => true).ToListAsync();

        public async Task CreateAsync(Laptop laptop) =>
            await _laptops.InsertOneAsync(laptop);
    }
}

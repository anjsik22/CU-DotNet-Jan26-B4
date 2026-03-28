using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TrackingServiceSetup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackingController : ControllerBase
    {
        [Authorize(Roles = "Manager")]
        [HttpGet("gps")]
        public IActionResult GetGpsData()
        {
            var random = new Random();

            var data = new[]
            {
        new {
            TruckId = "101",
            Latitude = 30.7333 + random.NextDouble() / 100,
            Longitude = 76.7794 + random.NextDouble() / 100,
            Location = "Chandigarh",
            Status = "In Transit",
            Timestamp = DateTime.UtcNow
        },
        new {
            TruckId = "102",
            Latitude = 28.7041 + random.NextDouble() / 100,
            Longitude = 77.1025 + random.NextDouble() / 100,
            Location = "Delhi",
            Status = "Delivered",
            Timestamp = DateTime.UtcNow
        },
        new {
            TruckId = "103",
            Latitude = 31.3260 + random.NextDouble() / 100,
            Longitude = 75.5762 + random.NextDouble() / 100,
            Location = "Jalandhar",
            Status = "Idle",
            Timestamp = DateTime.UtcNow
        },
        new {
            TruckId = "104",
            Latitude = 19.0760 + random.NextDouble() / 100,
            Longitude = 72.8777 + random.NextDouble() / 100,
            Location = "Mumbai",
            Status = "In Transit",
            Timestamp = DateTime.UtcNow
        },
        new {
            TruckId = "105",
            Latitude = 13.0827 + random.NextDouble() / 100,
            Longitude = 80.2707 + random.NextDouble() / 100,
            Location = "Chennai",
            Status = "Delivered",
            Timestamp = DateTime.UtcNow
        },
        new {
            TruckId = "106",
            Latitude = 22.5726 + random.NextDouble() / 100,
            Longitude = 88.3639 + random.NextDouble() / 100,
            Location = "Kolkata",
            Status = "In Transit",
            Timestamp = DateTime.UtcNow
        },
        new {
            TruckId = "107",
            Latitude = 12.9716 + random.NextDouble() / 100,
            Longitude = 77.5946 + random.NextDouble() / 100,
            Location = "Bangalore",
            Status = "Idle",
            Timestamp = DateTime.UtcNow
        }
    };

            return Ok(data);
        }
    }
}

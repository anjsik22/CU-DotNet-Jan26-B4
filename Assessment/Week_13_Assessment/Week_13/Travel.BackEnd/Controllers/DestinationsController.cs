using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.BackEnd.Data;
using Travel.BackEnd.DTOs;
using Travel.BackEnd.Exceptions;
using Travel.BackEnd.Models;
using Travel.BackEnd.Services;

namespace Travel.BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationsController : ControllerBase
    {
        private readonly IDestinationService _service;

        public DestinationsController(IDestinationService service)
        {
            _service = service;
        }

        // GET: api/destinations
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAllAsync();
            return Ok(data);
        }

        // GET: api/destinations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var dest = await _service.GetByIdAsync(id);

            if (dest == null)
                throw new DestinationNotFoundException($"Destination {id} not found");

            return Ok(dest);
        }

        // POST: api/destinations
        [HttpPost]
        public async Task<IActionResult> Create(DestinationResponseDTO dto)
        {
            var destination = new Destination
            {
                CityName = dto.CityName,
                Country = dto.Country,
                Description = dto.Description,
                Rating = dto.Rating,
                LastVisited=dto.LastVisited=DateTime.Now
            };


            await _service.AddAsync(destination);

            return Ok();
        }

        // PUT: api/destinations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Destination destination)
        {
            if (id != destination.Id)
                return BadRequest();

            var existing = await _service.GetByIdAsync(id);
            if (existing == null)
                throw new DestinationNotFoundException($"Destination {id} not found");

            await _service.UpdateAsync(destination);
            return NoContent();
        }

        // DELETE: api/destinations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id); 
            return NoContent();
        }
    }
}

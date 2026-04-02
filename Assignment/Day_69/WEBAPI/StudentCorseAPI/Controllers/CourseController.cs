using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentCorseAPI.Data;
using StudentCorseAPI.DTOs;
using StudentCorseAPI.Models;

namespace StudentCorseAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json", "application/xml")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CourseController(AppDbContext context)
        {
            _context = context;
        }

       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseResponseDTO>>> GetAll()
        {
            var courses = await _context.Courses
                .Include(c => c.StudentCourses)
                .ThenInclude(sc => sc.Student)
                .ToListAsync();

            var result = courses.Select(c => new CourseResponseDTO
            {
                Id = c.Id,
                Title = c.Title,
                Credits = c.Credits,
                Students = c.StudentCourses
                    .Select(sc => new StudentDTO
                    {
                        Name = sc.Student.Name,
                        Email = sc.Student.Email,
                        Age = sc.Student.Age
                    }).ToList()
            });

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseResponseDTO>> Get(int id)
        {
            var course = await _context.Courses
                .Include(c => c.StudentCourses)
                .ThenInclude(sc => sc.Student)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (course == null)
                return NotFound();

            var result = new CourseResponseDTO
            {
                Id = course.Id,
                Title = course.Title,
                Credits = course.Credits,
                Students = course.StudentCourses
                    .Select(sc => new StudentDTO
                    {
                        Name = sc.Student.Name,
                        Email = sc.Student.Email,
                        Age = sc.Student.Age
                    }).ToList()
            };

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Course>> Create(CourseDTO dto)
        {
            var course = new Course
            {
                Title = dto.Title,
                Credits = dto.Credits
            };

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = course.Id }, course);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CourseDTO dto)
        {
            var course = await _context.Courses.FindAsync(id);

            if (course == null)
                return NotFound();

            course.Title = dto.Title;
            course.Credits = dto.Credits;

            await _context.SaveChangesAsync();

            return Ok(course);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var course = await _context.Courses.FindAsync(id);

            if (course == null)
                return NotFound();

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}


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
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentResponseDTO>>> GetAll()
        {
            var students = await _context.Students
        .Include(s => s.StudentCourses)
        .ThenInclude(sc => sc.Course)
        .Select(s => new StudentResponseDTO
        {
            Id = s.Id,
            Name = s.Name,
            Email = s.Email,
            Age = s.Age,
            Courses = s.StudentCourses.Select(sc => new CourseDTO
            {
                Id = sc.Course.Id,
                Title = sc.Course.Title,
                Credits = sc.Course.Credits
            }).ToList()
        })
        .ToListAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentResponseDTO>> Get(int id)
        {
            var student = await _context.Students
                .Include(s => s.StudentCourses)
                .ThenInclude(sc => sc.Course)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (student == null)
                return NotFound();

            var result = new StudentResponseDTO
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Age = student.Age,
                Courses = student.StudentCourses
    .Select(sc => new CourseDTO
    {
        Id = sc.Course.Id,
        Title = sc.Course.Title,
        Credits = sc.Course.Credits
    })
    .ToList()
            };

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> Create(StudentDTO dto)
        {
            var student = new Student
            {
                Name = dto.Name,
                Email = dto.Email,
                Age = dto.Age
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, StudentDTO dto)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
                return NotFound();

            student.Name = dto.Name;
            student.Email = dto.Email;
            student.Age = dto.Age;

            await _context.SaveChangesAsync();

            return Ok(student);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
                return NotFound();

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent(); // ⭐ better
        }
    }
}

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
    public class EnrollmentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EnrollmentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Enroll(EnrollDTO dto)
        {
            var exists = await _context.StudentCourses
                .AnyAsync(sc => sc.StudentId == dto.StudentId && sc.CourseId == dto.CourseId);

            if (exists)
                return BadRequest("Already enrolled");

            var enrollment = new StudentCourse
            {
                StudentId = dto.StudentId,
                CourseId = dto.CourseId
            };

            _context.StudentCourses.Add(enrollment);
            await _context.SaveChangesAsync();

            return Ok("Enrollment successful");
        }
    }
}

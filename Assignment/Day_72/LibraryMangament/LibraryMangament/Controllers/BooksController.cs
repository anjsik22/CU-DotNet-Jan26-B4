using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryMangament.Data;
using LibraryMangament.Models;
using LibraryMangament.DTOs;

namespace LibraryMangament.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly MyAppDbContext _context;
        private readonly ILogger<BooksController> _logger;
        public BooksController(MyAppDbContext context, ILogger<BooksController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            _logger.LogInformation("GET /api/books called");

            try
            {
                var books = await _context.Books
                    .Include(b => b.Author) // EF JOIN
                    .Select(b => new
                    {
                        b.BookId,
                        b.Title,
                        b.Genre,
                        Author = new
                        {
                            b.Author.AuthorId,
                            b.Author.Name,
                            b.Author.Country
                        }
                    })
                    .ToListAsync();

                return Ok(books);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching books");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetBook(int id)
        {
            _logger.LogInformation($"GET /api/books/{id} called");

            try
            {
                var book = await _context.Books
                    .Include(b => b.Author)
                    .Where(b => b.BookId == id)
                    .Select(b => new
                    {
                        b.BookId,
                        b.Title,
                        b.Genre,
                        Author = new
                        {
                            b.Author.AuthorId,
                            b.Author.Name,
                            b.Author.Country
                        }
                    })
                    .FirstOrDefaultAsync();

                if (book == null)
                {
                    _logger.LogWarning($"Book with ID {id} not found");
                    return NotFound();
                }

                return Ok(book);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching book {id}");
                return StatusCode(500, "Internal server error");
            }
        }


        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, UpdateBookDTO dto)
        {
            _logger.LogInformation($"PUT /api/books/{id} called");

            try
            {
                var book = await _context.Books.FindAsync(id);

                if (book == null)
                {
                    _logger.LogWarning($"Book with ID {id} not found");
                    return NotFound();
                }

                // Update fields
                book.Title = dto.Title;
                book.Genre = dto.Genre;
                book.AuthorId = dto.AuthorId;

                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating book");
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(CreateBookDTO dto)
        {
            _logger.LogInformation("POST /api/books called");

            try
            {
                var book = new Book
                {
                    Title = dto.Title,
                    Genre = dto.Genre,
                    AuthorId = dto.AuthorId
                };

                _context.Books.Add(book);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetBook), new { id = book.BookId }, book);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating book");
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.BookId == id);
        }
    }
}

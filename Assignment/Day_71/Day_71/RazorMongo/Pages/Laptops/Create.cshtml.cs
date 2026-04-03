using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorMongo.Models;
using RazorMongo.Services;

namespace RazorMongo.Pages.Laptops
{
    public class CreateModel : PageModel
    {
        private readonly LaptopService _service;

        [BindProperty]
        public Laptop Laptop { get; set; }

        public CreateModel(LaptopService service)
        {
            _service = service;
        }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            await _service.CreateAsync(Laptop);

            TempData["msg"] = "Laptop added successfully!";
            return RedirectToPage("/Laptops/Index");
        }
    }
}
